using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomData 
{ 
    public int succes { get; set; }
    public List<Data> data { get; set; }
}
[System.Serializable]
public class Data
{
    public int id_room { get; set; }
    public int id_user { get; set; }
    public int code { get; set; }
    public int open { get; set; }

}

