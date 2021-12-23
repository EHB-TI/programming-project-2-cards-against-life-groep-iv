using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlayerReady : NetworkBehaviour
{

    public CardsManager PlayerManager;
    public Text numberOfReady;
    // public Text hostText;
   // public string actualPlayersText;
    public Text numberOfPlayers;
    public int nPlayers;
    //public Text statusText;
    public int playersNeeded;
    [SyncVar(hook = nameof(startGame))]
    public int ready = 0;
    public PG13API api;

   // public int playersReady;


    public string mainText;

    //SyncVar declaration requires the [SyncVar] attribute immediately preceding it!
    [SyncVar]
    public int playersReady = 1;

    public bool server = false;

    [SyncVar(hook = nameof(changedStatus))]
    public int status = -1;  //0 = HOST IS PICKING - 1 = PLAYERS ARE PICKING - 2 = HOST CHOOSING WINNER - 3 - RESULTS

    public List<CardsManager> players = new List<CardsManager>();


    //List where the cards which have been chosen will be stored
    [SyncVar]
    public List<string> cardChosen = new List<string>();

    //The funniest card the host chose
    [SyncVar]
    public string hostFunniest = "0";

    //the id of the player of the funniest card
    [SyncVar]
    public int hostSelection = 0;
    

    //Controlling the number of rounds
    public GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    //WHEN A PLAYER CONNECTS, ADD THE PLAYER TO A LIST OF PLAYERS
    public void addPlayer(CardsManager player)
    {
        if(players.Count == 0)
        {
            nPlayers = 0;
        }
        players.Add(player);
        nPlayers++;
        numberOfPlayers.text = "Players: " + nPlayers + " /4";
        cardChosen.Add("-1");

        //if all the players have joined the game, then start the game
        if (players.Count < playersNeeded)
        {
            int needed = playersNeeded - players.Count;
           // statusText.text = "Waiting for players; needed " + needed + " more players";
            player.statusText.GetComponent<Text>().text = "Waiting for players; needed " + needed + " more players";
            Debug.Log("waiting for players");
            if (isServer)
            {
                player.GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "YOU ARE THE HOST";
                Debug.Log("HOSTITO");
            }
            else
                player.GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "YOU ARE A CLIENT";

            //PlayerManager.GetComponent<CardsManager>().CmdClientshowText(gameObject);
           
        }
       
        else
        {
            ready = 1;
            status = 0;
            Debug.Log("ALL READY");

        }

    }


    //SUBMIT BUTTON CONTROLLER
    public void OnClick()
    {
        if (ready == 1)
        {
            server = isServer;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<CardsManager>();

            //locate the PlayerManager in this Client and request the Server to deal cards
            if (!isServer && PlayerManager.isReady == false && status == 1)
            {
                //PICK SENTENCE

                playersReady++;
                PlayerManager.isReady = true;
                PlayerManager.CmdIncrementClick(gameObject);
                Debug.Log(PlayerManager.name);
                //text.text = "Players: " + playersReady + " /2";
                Debug.Log("PlayersReady:: " + playersReady);
                Debug.Log(playersNeeded - 1);
                

                if(playersReady >= playersNeeded-1)
                {
                    NetworkIdentity networkIdentityd = NetworkClient.connection.identity;
                    PlayerManager = networkIdentityd.GetComponent<CardsManager>();
                    Debug.Log("gets in change state");
                    status = 2;
                    //call status in al CardsManager
                    playersReady = 0;
                    PlayerManager.changeStatus(gameObject);
                   
                }

            }
            else if (isServer && status == 0)
            {
                PlayerManager.CmdshowText(gameObject);
                status = 1;
               // players[0].statusText.GetComponent<Text>().text = " Waiting for clients to pick!";
                for (int i = 1; i< players.Count; i++)
                {
                   // players[i].statusText.GetComponent<Text>().text = " It's your turn! Choose a card";
                    Debug.Log(i);
                    Debug.Log(players[i].isServer);
                }
                //show text to players
            }
           
            //if clicked on submit (and its the turn of the server) then change to show results
            if(isServer && status == 2)
            {

                status = 3;
            }

        }
    }


    //CHANGE_CARDS BUTTON!
    public void OnclickChange()
    {
        if (ready == 1)
        { 
        if (isServer && status == 0)
        {
            // CHANGE HOST TEXT FROM API
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<CardsManager>();
                //PlayerManager.changeHostText();
                //players[0].GetComponent<CardsManager>().CmdshowText(gameObject);
                PlayerManager.CmdshowText(gameObject);
                mainText = PlayerManager.apiSentence;
                PlayerManager.mainText.GetComponent<Text>().text = mainText;
                Debug.Log("calling CardsManager");

        }
        else if (!isServer && status == 1)
        {
           
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<CardsManager>();
                //PlayerManager.changeCards();
                //PlayerManager.GetComponent<CardsManager>().CmdClientshowText(gameObject);
                foreach (GameObject prefab in PlayerManager.prefabs)
                {
                    prefab.GetComponent<Text>();
                    string apisentence = api.randomCard();
                    prefab.transform.GetChild(1).GetComponent<Text>().text = apisentence;
                    Debug.Log("card mode");

                }
            }
        }
    }

    //CARDS BUTTON! (WHEN CLIENT CHOOSES A CARD, STORE THIS CARD)
    [Client]
    public void onCardClick(int number)
    {
        if(status == 1 && !isServer)
        {
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<CardsManager>();
            PlayerManager.selection = number;
            Debug.Log("clicked! " + PlayerManager.selection);
            Debug.Log(PlayerManager.name + " has clicked " + number);
            PlayerManager.selectCard(PlayerManager.prefabs[number].transform.GetChild(1).GetComponent<Text>().text, number);
            
            //cardChosen[PlayerManager.nThisPlayer] = PlayerManager.prefabs[number].transform.GetChild(1).GetComponent<Text>().text;
        }

        if(status == 2 && isServer)
        {
            hostFunniest = PlayerManager.prefabs[number].transform.GetChild(1).GetComponent<Text>().text;
            hostSelection = number;

            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<CardsManager>();
            PlayerManager.funniestCard(number);
        }
        else if(status == 2)
        {
            hostFunniest = PlayerManager.prefabs[number].transform.GetChild(1).GetComponent<Text>().text;
        }
    }

    public void startGame(int oldReady, int newReady)
    {
        if (isServer && newReady ==1)
        {
            //players[0].GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "New Card";
            // statusText.text = "New Card";
            //CALL NEWSENTENCE
            players[0].GetComponent<CardsManager>().mainText.GetComponent<Text>().text = api.randomQuestion();
        }
        else if (!isServer && newReady==1)
        {
           // statusText.text = "waiting for host";
            foreach (CardsManager player in players)
            {
                //player.GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "New Card";
                player.GetComponent<CardsManager>().mainText.GetComponent<Text>().text = api.randomCard();
            }
        }
    }


    //CHANGING TEXTS AND VARIABLES WHEN THE STATUS OF THE GAME CHANGES
    public void changedStatus(int oldStatus, int newStatus)
    {

        if (newStatus == 0)
        {
            if (isServer)
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();

                PlayerManager.statusText.GetComponent<Text>().text = "It´s your turn! Pick a sentence";
                mainText = PlayerManager.apiSentence;
                //statusText.text = "It´s your turn! Pick a sentence";
                foreach (GameObject prefab in PlayerManager.prefabs)
                {
                    //prefabs.Add(GameObject.Find("Pos1").transform.GetChild(0).gameObject);
                    // prefab.GetComponent<Text>().text = "Player Picking";
                    prefab.GetComponent<Text>();
                    prefab.transform.GetChild(1).GetComponent<Text>().text = "Player Picking";
                    Debug.Log("card mode");
                }
                for (int i = 1; i < players.Count; i++)
                {
                    players[i].GetComponent<CardsManager>().mainText.GetComponent<Text>().text = mainText;
                }
            }
            if (!isServer)
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                
                PlayerManager.statusText.GetComponent<Text>().text = "Waiting for Host to pick a sentence";
                PlayerManager.changeTextToCero(PlayerManager);

                //statusText.text = "It´s your turn! Pick a sentence";
                foreach (GameObject prefab in PlayerManager.prefabs)
                {
                    //prefabs.Add(GameObject.Find("Pos1").transform.GetChild(0).gameObject);
                    // prefab.GetComponent<Text>().text = "Player Picking";
                    prefab.GetComponent<Text>();
                    prefab.transform.GetChild(1).GetComponent<Text>().text = "This is a card!!";
                    Debug.Log("card mode");
                }
                for (int i = 1; i < players.Count; i++)
                {
                    players[i].GetComponent<CardsManager>().mainText.GetComponent<Text>().text = mainText;
                }
            }
        }

        if (oldStatus == 0 && newStatus == 1)
        {
            if (isServer)
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                
                PlayerManager.statusText.GetComponent<Text>().text =  "Waiting for players to pick!";
            }
            else
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                PlayerManager.statusText.GetComponent<Text>().text = "It's your turn, pick a sentence!!";
                PlayerManager.mainText.GetComponent<Text>().text = mainText;
            }

        

        }

        if(newStatus == 2)
        {
            changingText();
            if (isServer)
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                PlayerManager.mainText.GetComponent<Text>().text = mainText;

                
                
                for(int i = 0; i< players.Count; i++)
                {
                    //  int selection = players[i].selection;
                    //  Debug.Log("player " + i + "selected " + players[i].selection);
                    Debug.Log(i);
                    PlayerManager.prefabs[i].transform.GetChild(1).GetComponent<Text>().text = cardChosen[i];
                    
                   // Debug.Log("actual host text: " + PlayerManager.prefabs[i].transform.GetChild(1).GetComponent<Text>().text);
                   // Debug.Log("changed host text: " + players[i].prefabs[selection].transform.GetChild(1).GetComponent<Text>().text);
                    players[i].statusText.GetComponent<Text>().text = "Waiting for Host to pick";
                   
                }
              
                
                PlayerManager.statusText.GetComponent<Text>().text = "PICK THE FUNNIEST CAR";
                PlayerManager.changingText();
                
                
                
            }
            else 
            {

                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                PlayerManager.statusText.GetComponent<Text>().text = "Waiting for Host to pick";
                Debug.Log("Waiting for Host to pick in Client");
            }
        }

        if(newStatus == 3)
        {
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<CardsManager>();
            PlayerManager.statusText.GetComponent<Text>().text = "AND THE FUNNIEST CARD IS...";
            PlayerManager.showFunniest();
            Debug.Log("showing the funniest card in " + PlayerManager.name);
            PlayerManager.funniest.text = hostFunniest.ToString();

            PlayerManager.funniest.GetComponent<Animation>().Play();

            // callcoroutine();
            gameManager.UpdateTurnsPlayed();
            status = 0;



        }

    }



    public void callcoroutine()
    {
        StartCoroutine(reestarting());
    }

    //?
    [Server]
    IEnumerator reestarting()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        gameManager.UpdateTurnsPlayed();
        status = 0;
       
        
    }


    [Command]
    public void changingText()
    {
        changingTextRpc();
    }

    [ClientRpc]
    public void changingTextRpc()
    {
        foreach (CardsManager player in players)
        {
            player.mainText.GetComponent<Text>().text = mainText; 
        }


    }

}
