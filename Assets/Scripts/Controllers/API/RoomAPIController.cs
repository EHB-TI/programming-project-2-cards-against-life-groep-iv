using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using SimpleJSON;

[System.Serializable]
public class RoomAPIController : MonoBehaviour
{
   public RoomController roomController;
   public List<Room> rooms;

    IEnumerator Start()
    {
        RoomData Data;
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/rooms");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            Data = JsonConvert.DeserializeObject<RoomData>(request.downloadHandler.text);
            rooms = Data.Rooms;
            roomController.showRooms(rooms);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }

    public void MakeRoom(int open, int cat)
    {
        StartCoroutine(InsertRoom(open, cat));
    }

    public int generateRandom()
    {
        return Random.Range(0, 2000);
    }

    IEnumerator InsertRoom(int open, int cat)
    {
        WWWForm form = new WWWForm();
        form.AddField("id_user", 2);
        form.AddField("code", generateRandom());
        form.AddField("cat", cat);
        form.AddField("pub", open);
        form.AddField("open",1);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/TestApi/createRooms.php", form);
        yield return www.SendWebRequest();
        if (www.responseCode == 200)
        {
            Debug.Log("Room created succesfully!");
        }
        else
        {
            Debug.Log("Room creation failed!. Error: " + www.error);
            InsertRoom(open, cat);
        }
    }
}


