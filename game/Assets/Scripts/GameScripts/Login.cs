using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    //Author: De Vogel Ryan
    //source: https://www.youtube.com/watch?v=SKbY-0zt2VE&t=141s It's a serie

    public GameObject nameField;
    public GameObject passwordField;
 
    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        //source: https://docs.unity3d.com/Manual/UnityWebRequest-SendingForm.html

        var username = nameField.GetComponent<TMP_InputField>().text;
        var password = passwordField.GetComponent<TMP_InputField>().text;

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/TestApi/login.php", form);//send post request to php server
        yield return www.SendWebRequest();
        if (www.responseCode == 200)//check for succes. 
        {
            DBManager.username = username;
            Debug.Log("Sucessfully logged in!");
            SceneManager.LoadScene(4); 
        }
        else
        {
            Debug.Log("Wrong username or password!");
        }
    }

    public void VerifyInputs()
    {
        //This will only make the button clickable if the following condition is true
       // submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 8);
    }

}
