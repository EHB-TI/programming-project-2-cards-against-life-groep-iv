using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player
{
    public int id;
    public string name;
    public bool myTurn;
    public Player(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
