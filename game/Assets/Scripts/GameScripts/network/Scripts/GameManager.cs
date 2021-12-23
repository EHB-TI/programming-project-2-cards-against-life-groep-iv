using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    //This simple GameManager script is attached to a Server-only game object, implementing game logic tracked by the Server
    public int TurnsPlayed = 0;
    public int numberOfPlayers = 0;
    public Text turns;

    private void Start()
    {
        turns = GameObject.Find("Turns").GetComponent<Text>();
    }
    public void UpdateTurnsPlayed()
    {
        TurnsPlayed++;
        turns.text = "Turns played: " + turns;
    }
}
