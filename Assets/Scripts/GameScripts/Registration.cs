using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

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
        Debug.Log(nameField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/TestApi/register.php", form);
        yield return www.SendWebRequest();

        if(www.responseCode == 200)
        {
            Debug.Log("User created succesfully!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("User creation failed!. Error: " + www.error);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 8);
    }

}
   
