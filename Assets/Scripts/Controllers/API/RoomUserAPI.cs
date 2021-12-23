using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RoomUserAPI : MonoBehaviour
{
  public RoomAPIController roomAPI;

    public void insertUser()
    {
        StartCoroutine(insertUserInRoom());
    }

    IEnumerator insertUserInRoom()
    {

        WWWForm form = new WWWForm();
        form.AddField("id_user", 2);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/TestApi/createRooms.php", form);
        yield return www.SendWebRequest();
        if (www.responseCode == 200)
        {
            Debug.Log("User inserted succesfully!");
        }
        else
        {
            Debug.Log("user insert failed!. Error: " + www.error);
        }
    }

}
