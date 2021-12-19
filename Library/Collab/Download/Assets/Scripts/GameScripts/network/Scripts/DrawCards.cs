using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DrawCards : NetworkBehaviour
{
    //public PlayerManager PlayerManager;
    public CardsManager CardsManager;

    //OnClick() is called by the OnClick() event within the Button component
    public void OnClick()
    {
        //locate the PlayerManager in this Client and request the Server to deal cards
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        CardsManager = networkIdentity.GetComponent<CardsManager>();
        CardsManager.CmdDealCards();
    }

}
