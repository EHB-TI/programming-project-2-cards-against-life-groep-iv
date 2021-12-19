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
    public string actualPlayersText;
    public Text numberOfPlayers;
    public int nPlayers;
    public Text statusText;
    public int playersNeeded;
    [SyncVar(hook = nameof(startGame))]
    public int ready = 0;

   // public int playersReady;


    public string mainText;

    //SyncVar declaration requires the [SyncVar] attribute immediately preceding it!
    [SyncVar]
    public int playersReady = 1;

    public bool server = false;

    [SyncVar(hook = nameof(changedStatus))]
    public int status = -1;  //0 = HOST IS PICKING - 1 = PLAYERS ARE PICKING - 2 = HOST CHOOSING WINNER - 3 - RESULTS

    public List<CardsManager> players = new List<CardsManager>();

    public void addPlayer(CardsManager player)
    {
        if(players.Count == 0)
        {
            nPlayers = 0;
        }
        players.Add(player);
        nPlayers++;
        numberOfPlayers.text = "Players: " + nPlayers + " /4";

        if (players.Count < playersNeeded)
        {
            int needed = playersNeeded - players.Count;
            statusText.text = "Waiting for players; needed " + needed + " more players";
            Debug.Log("waiting for players");
            if (isServer)
            {
                player.GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "YOU ARE THE HOST";
                Debug.Log("HOSTITO");
            }
            else
                player.GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "YOU ARE A CLIENT";
        }

       


        else
        {
            ready = 1;
            status = 0;
            Debug.Log("ALL READY");
        }
        Debug.Log("why not ready" + players.Count + playersNeeded);




        /*  if (!isServer)
          {
              foreach (GameObject prefab in player.prefabs)
              {
                  prefab.transform.GetChild(1).GetComponent<Text>().text = "This is your card!";
              }
          }
        */
    }


    //SUBMIT BUTTON!
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
                //hostText.text = "HUAJAJAJAJ IM VERY FUNNY__";
                
                PlayerManager.isReady = true;
                PlayerManager.CmdIncrementClick(gameObject);
                Debug.Log(PlayerManager.name);
                //text.text = "Players: " + playersReady + " /2";
                Debug.Log(playersReady);

                if(playersReady >= playersNeeded-1)
                {
                    status = 2;
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
            players[0].GetComponent<CardsManager>().CmdshowText(gameObject);
                Debug.Log("calling CardsManager");

        }
        else if (!isServer && status == 1)
        {
            //CHANGE GAMEMANAGER CARDS (CHANGE THE CARDS FROM THE PLAYER)
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<CardsManager>();
                //PlayerManager.changeCards();
                //PlayerManager.GetComponent<CardsManager>().CmdClientshowText(gameObject);
                foreach (GameObject prefab in PlayerManager.prefabs)
                {
                    //prefabs.Add(GameObject.Find("Pos1").transform.GetChild(0).gameObject);
                    // prefab.GetComponent<Text>().text = "Player Picking";
                    prefab.GetComponent<Text>();
                    prefab.transform.GetChild(1).GetComponent<Text>().text = "New card!";
                    Debug.Log("card mode");
                }
            }
        }
    
    }

    public void startGame(int oldReady, int newReady)
    {
        if (isServer && newReady ==1)
        {
            players[0].GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "New Card";
           // statusText.text = "New Card";
            //CALL NEWSENTENCE
        }
        else if (!isServer && newReady==1)
        {
            statusText.text = "waiting for host";
            foreach (CardsManager player in players)
            {
                player.GetComponent<CardsManager>().mainText.GetComponent<Text>().text = "New Card";
            }
        }
    }

    public void changedStatus(int oldStatus, int newStatus)
    {

        if (newStatus == 0)
        {
            if (isServer)
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                submitText();
                PlayerManager.statusText.GetComponent<Text>().text = "It큦 your turn! Pick a sentence";
                //statusText.text = "It큦 your turn! Pick a sentence";
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
                submitText();
                PlayerManager.statusText.GetComponent<Text>().text = "Waiting for Host to pick a sentence";
                //statusText.text = "It큦 your turn! Pick a sentence";
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
                submitText();
                PlayerManager.statusText.GetComponent<Text>().text =  "Waiting for players to pick!";
            }
            else
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                PlayerManager.statusText.GetComponent<Text>().text = "It's your turn, pick a sentence!!";
            }

            /*
            Debug.Log("CHANGED STATUS!!");
            if (isServer)
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
                submitText();
                statusText.text = "It큦 your turn! Pick a sentence";
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
            else
            {
                NetworkIdentity networkIdentity = NetworkClient.connection.identity;
                PlayerManager = networkIdentity.GetComponent<CardsManager>();
            }
            */

        }
    }

    public void submitText()
    {

    }
}
