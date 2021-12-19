using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebTest : MonoBehaviour
{
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/rooms");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            getRooms(request);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }

    public void getRooms(UnityWebRequest request)
    {
        RoomData data = JsonConvert.DeserializeObject<RoomData>(request.downloadHandler.text);

        Debug.Log(data.data[0].code);

        foreach (Data x in data.data)
        {
            Debug.Log(x.code);
        }
    } 

}


