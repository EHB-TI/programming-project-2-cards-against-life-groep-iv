using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
     //Author: De Vogel Ryan
    //source: https://www.youtube.com/watch?v=SKbY-0zt2VE&t=141s It's a serie

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        //source: https://docs.unity3d.com/Manual/UnityWebRequest-SendingForm.html

        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);//send post request to php server
        yield return www.SendWebRequest();
        if (www.responseCode == 200)//check for succes. 
        {
            DBManager.username = nameField.text;
            Debug.Log("Sucessfully logged in!");
            //DBManager.score = int.Parse(www.downloadHandler.text.Split('\t')[1]);
            //Load the main menu
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Wrong username or password!");
        }
    }

    public void VerifyInputs()
    {
        //This will only make the button clickable if the following condition is true
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 8);
    }

}
