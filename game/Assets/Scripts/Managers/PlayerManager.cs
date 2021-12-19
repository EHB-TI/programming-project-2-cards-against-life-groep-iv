using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<Player> players = new List<Player>();

    private void Awake()
    {
        instance = this;
    }

    internal void AssingTurn(int currentPlayerTurn)
    {
        
        foreach(Player player in players)
        {
            if(player.id == currentPlayerTurn)
            {
                player.myTurn = true;
            }
            else
            {
                player.myTurn = false;
            }
        }

       /*
         Player player = players.Find(x => x.id == currentPlayerTurn);
        player.myTurn = true;
       */

      
        //  player.myTurn = player.id == currentPlayerTurn;
         
        
    }

    public Player FindPlayerByID(int id)
    {
        Player foundPlayer = null;
        foreach(Player player in players)
        {
            foundPlayer = player;
        }
        return foundPlayer;
    }
}
