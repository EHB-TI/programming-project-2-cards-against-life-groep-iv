using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PrivateManager : MonoBehaviour
{
    public RoomAPIController roomAPI;
    public GameObject inputField;
    public SceneManagerScript sceneManager;
    public void checkCode()
    {
        var input = inputField.GetComponent<TMP_InputField>().text;
        int number;
        foreach (Room r in roomAPI.rooms)
        {
            if (int.TryParse(input, out number))
            {
                if (r.code == int.Parse(input))
                {
                    Debug.Log("Correct code");
                    sceneManager.OpenScene(6);
                    //toevoegen aan RoomUserDB
                  //string playerDisplay = "Player: " + DBManager.username;
                }
            }
            else
            {
                Debug.Log("wrong value");
            }
        }


    }
}

