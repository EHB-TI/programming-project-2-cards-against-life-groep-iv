using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class FriendsData
    {

        public Friend Friend { get; set; }
        public List<Friend> friends { get; set; }
    }

    [System.Serializable]
    public class Friend
    {
        public Friend(int id_friend)
        {
            this.id_friend = id_friend;
        }
        public int id_user { get; set; }
        public int id_friend { get; set; }
    }


