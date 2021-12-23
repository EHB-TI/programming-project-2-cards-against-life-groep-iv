using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomUserData
{ 
        public int success { get; set; }
        public List<RoomsUser> RoomsUsers { get; set; }

    }
[System.Serializable]
    public class RoomsUser
    {
        public int room_id { get; set; }
        public int user_id { get; set; }
    }



