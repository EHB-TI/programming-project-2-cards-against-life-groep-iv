using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomData 
{
    public RoomData(int success, List<Room> rooms)
    {
        this.success = success;
        Rooms = rooms;
    }

    public int success { get; set; }
    public List<Room> Rooms { get; set; }
}

[System.Serializable]
public class Room
{
    public Room(int id, int id_user, int code, int cat, int pub, int open)
    {
        this.room_id = id;
        this.id_user = id_user;
        this.code = code;
        this.cat = cat;
        this.pub = pub;
        this.open = open;
    }

    public int room_id{ get; set; }
    public int id_user { get; set; }
    public int code { get; set; }
    public int cat { get; set; }
    public int pub { get; set; }
    public int open { get; set; }
}

