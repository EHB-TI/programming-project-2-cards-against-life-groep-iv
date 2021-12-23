using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using SimpleJSON;
public class UsersAPI : MonoBehaviour
{
    public UserController usersController;

    public UserData Data;
    public List<User> users;
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/users");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            Data = JsonConvert.DeserializeObject<UserData>(request.downloadHandler.text);
            users = Data.Users;
           // usersController.showUsers(users);  
            getAllUsers(Data);
        }
        else
        {
            Debug.Log("Something went wrong");
        }


    }

    public void getAllUsers(UserData users)
    {

        foreach (User x in users.Users)
        {
           Debug.Log(x.username);    
        }
    }

}
