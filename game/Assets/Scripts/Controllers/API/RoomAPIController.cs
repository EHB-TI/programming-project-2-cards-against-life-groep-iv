using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

[System.Serializable]
public class RoomAPIController : MonoBehaviour
{
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/rooms");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            RoomData rooms = JsonConvert.DeserializeObject<RoomData>(request.downloadHandler.text);

            getRooms(rooms);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }

    public void getRooms(RoomData rooms)
    {
        Debug.Log(rooms.data[0]);

        foreach (Data x in rooms.data)
        {
            Debug.Log(x.code);
        }
    }
}
