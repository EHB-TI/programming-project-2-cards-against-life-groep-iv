using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;
    readonly string getURL = "urlGetphp";
    readonly string postURL = "urlPostphp";
    readonly string postURLBool = "urlPostphp";
    readonly string gettURLBool = "urlPostphp";
    public int playerNumber;



    //testing connection
    public Text getText;
    public string allready;


    public void Start()
    {
        /*       public Button submitButton;
          readonly string getURL = "urlGetphp";
          readonly string postURL = "urlPostphp";
          readonly string postURLBool = "urlPostphp";
          readonly string gettURLBool = "urlPostphp";
        */




    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        //source: https://docs.unity3d.com/Manual/UnityWebRequest-SendingForm.html

        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User created succesfully!");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed!. Error: " + www.error);
        }
    }

    IEnumerator checkReady()
    {
        WWWForm form = new WWWForm();
        // form.AddField("player1ready", true);


        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User created succesfully!");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed!. Error: " + www.error);
        }
    }

    IEnumerator getRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User created succesfully!");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            getText.text = www.downloadHandler.text;

        }
        else
        {
            Debug.Log("User creation failed!. Error: " + www.error);
        }
    }

    IEnumerator postReadyRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("player" + playerNumber, "true");
        // form.AddField("password", passwordField.text);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User created succesfully!");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);  gettURLBool
            UnityWebRequest getter = UnityWebRequest.Get(gettURLBool);
            allready = getter.downloadHandler.text;
            //CHECK ALLREADY TO SEE IF ALL PLAYERS ARE READY TO PLAY


        }
        else
        {
            Debug.Log("User creation failed!. Error: " + www.error);
        }
    }

}


