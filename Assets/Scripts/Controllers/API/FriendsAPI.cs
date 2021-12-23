using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using SimpleJSON;
public class FriendsAPI : MonoBehaviour
{

    public FriendsController friendsController;

    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://test-api-vougel.herokuapp.com/friends");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            FriendsData Data = JsonConvert.DeserializeObject<FriendsData>(request.downloadHandler.text);
            //friendsController.showFriends(Data.friends);
            getFriendsData(Data);
        }
        else
        {
            Debug.Log("Something went wrong");
        }

    }

    public void getFriendsData(FriendsData friends)
    {
   
        foreach (Friend f in friends.friends)
        {
            Debug.Log(f.id_friend);
        }
    }
}
