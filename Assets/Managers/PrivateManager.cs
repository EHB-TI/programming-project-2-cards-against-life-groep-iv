using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateManager : MonoBehaviour
{
    RoomAPIController roomAPI;

   public void checkCode(List<Room> rooms)
    {
        Debug.Log(roomAPI.rooms);

       /* foreach (Room r in rooms)
        {
            if(r.code == )
        }*/
    }

    
}
