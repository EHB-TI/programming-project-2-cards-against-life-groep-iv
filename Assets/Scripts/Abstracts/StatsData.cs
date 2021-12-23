using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsData
{
    public int succes { get; set; }
    public List<Stats> Stats { get; set; }
}

[System.Serializable]
public class Stats
{
    public Stats(int id_user)
    {
        this.id_user = id_user;
    }
    public int id { get; set; }
    public int id_user { get; set; }
    public int games_played { get; set; }
    public int games_lost { get; set; }
    public int games_won { get; set; }
}