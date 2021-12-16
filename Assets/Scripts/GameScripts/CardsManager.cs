using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Mirror;

public class CardsManager : NetworkBehaviour, ISelectHandler
{
    // Start is called before the first frame update

    Card2 [] cardos;
    public Button[] buttons;
    public int clicked;
    public GameObject card1;
    public GameObject card2;

    //the cards List represents our deck of cards
    List<GameObject> cards = new List<GameObject>();
    List<GameObject> prefabs = new List<GameObject>();
    List<GameObject> originals = new List<GameObject>();

    public GameObject prefab;

    List<GameObject> PlayerArea = new List<GameObject>();


    public override void OnStartClient()
    {
        base.OnStartClient();

        PlayerArea.Add(GameObject.Find("Pos1"));
        PlayerArea.Add(GameObject.Find("Pos2"));
        PlayerArea.Add(GameObject.Find("Pos3"));
        PlayerArea.Add(GameObject.Find("Pos4"));
        // prefabs.Add(GameObject.Find("POS1").GetComponent<prefab>());
        for (int i = 0; i < PlayerArea.Count; i++)
        {
            Debug.Log(i);
            prefabs.Add(PlayerArea[i].transform.GetChild(0).gameObject);
        }
      
        
    }


    [Server]
    public override void OnStartServer()
    {
        //cards.Add(card1);
       // cards.Add(card2);
    }
    void Start()
    {
       // cardos = new Card2[4];
        //cards[0] = ??
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteCard1(int id)
    {
       // cards[0] = new Card2(id, sentence);
    }
    

    public void test(int id)
    {
        clicked = id;
       // buttons[id].
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
    }

    [Command]
    public void CmdDealCards()
    {
        Debug.Log("command CmdDealCards");
        //(5x) Spawn a random card from the cards deck on the Server, assigning authority over it to the Client that requested the Command. Then run RpcShowCard() and indicate that this card was "Dealt"
        for (int i = 0; i < 4; i++)
        {
            Vector2 pos = PlayerArea[i].transform.position;
            Destroy(prefabs[i].gameObject);
            GameObject card = Instantiate(card1, new Vector2(0.0f,0.0f), Quaternion.identity);
            prefabs[i] = card;
            NetworkServer.Spawn(card, connectionToClient);
           
            RpcShowCard(card, "Dealt", i);
        }
    }


    //ClientRpcs are methods requested by the Server to run on all Clients, and require the [ClientRpc] attribute immediately preceding them
    [ClientRpc]
    void RpcShowCard(GameObject card, string type, int number)
    {

        if (isServer)
        {
            card.GetComponent<CardFlipper>().Flip("host");
        }
        else
            card.GetComponent<CardFlipper>().Flip("player");


        Debug.Log("LLega ClientRcp");
        //if the card has been "Dealt," determine whether this Client has authority over it, and send it either to the PlayerArea or EnemyArea, accordingly. For the latter, flip it so the player can't see the front!
        if (type == "Dealt")
        {
            if (hasAuthority)
            {
                //GET NEW CARD!
                //DO SMT (SHOW WHO IS THE WINNER)
                card.transform.SetParent(PlayerArea[number].transform, false);
               // card.transform.position = new Vector3(0.0f, 0.0f);
               
                //INSTEAD OF "TEST" GET THE VALUE FROM DATABASE!
                card.GetComponentInChildren<Text>().text = "TEST";
                // card.transform.SetParent(PlayerArea.transform, false);
                Debug.Log("player with authority");
            }
            else
            {
                //  card.transform.SetParent(EnemyArea.transform, false);
                //  card.GetComponent<CardFlipper>().Flip();
                Debug.Log("player without authority");
            }
        }
        //if the card has been "Played," send it to the DropZone. If this Client doesn't have authority over it, flip it so the player can now see the front!
        else if (type == "Played")
        {
         
             if (!hasAuthority)
             {
                Debug.Log("played");
                ChangeCard(number);
                card.GetComponent<CardFlipper>().Flip("host");
             }
            
          
        }
    }

    [ClientRpc]
    void ChangeCard(int number)
    {
        Debug.Log("changing Card");
        // card.GetComponentInChildren<Text>().text = "Used card";
        prefabs[number].GetComponentInChildren<Text>().text = "Used CARD";
    }


    //PlayCard() is called by the DragDrop script when a card is placed in the DropZone, and requests CmdPlayCard() from the Server
    public void PlayCard(GameObject card, int number)
    {
        CmdPlayCard(card, number);
    }

    //CmdPlayCard() uses the same logic as CmdDealCards() in rendering cards on all Clients, except that it specifies that the card has been "Played" rather than "Dealt"
    [Command]
    void CmdPlayCard(GameObject card, int number)
    {
        RpcShowCard(card, "Played", number);

        //If this is the Server, trigger the UpdateTurnsPlayed() method to demonstrate how to implement game logic on card drop
        if (isServer)
        {
            UpdateTurnsPlayed();
        }
    }

    //UpdateTurnsPlayed() is run only by the Server, finding the Server-only GameManager game object and incrementing the relevant variable
    [Server]
    void UpdateTurnsPlayed()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.UpdateTurnsPlayed();
        RpcLogToClients("Turns Played: " + gm.TurnsPlayed);

    }

    //RpcLogToClients demonstrates how to request all clients to log a message to their respective consoles
    [ClientRpc]
    void RpcLogToClients(string message)
    {
        Debug.Log(message);
    }
}
