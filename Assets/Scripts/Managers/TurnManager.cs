using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public int currentPlayerTurn;

    private void Awake()
    {
        instance = this;
    }

    public void StartTurnGameplay(int playerID)
    {
        currentPlayerTurn = playerID;
        PlayerManager.instance.AssingTurn(currentPlayerTurn);
    }

    public void StartTurn()
    {

    }
    public void EndTurn()
    {

    }
}
