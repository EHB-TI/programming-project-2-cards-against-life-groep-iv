using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;


public class community : MonoBehaviour
{

    public InputField questionField;
    public InputField answerField;

    public Button submitButtonQ;
    public Button submitButtonA;
    public Button Btn;
    public void ComunityQuestion()
    {
        StartCoroutine(Question());
    }

    public void ComunityAnswer()
    {
        StartCoroutine(Answer());
    }

    IEnumerator Question()
    {
        WWWForm form = new WWWForm();
        form.AddField("question", questionField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/community.php", form);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Question created succesfully!");
        }
        else
        {
            Debug.Log("Question creation failed!. Error: " + www.error);
        }
    }

    IEnumerator Answer()
    {
        WWWForm form = new WWWForm();
        form.AddField("answer", answerField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/community.php", form);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Answer created succesfully!");
        }
        else
        {
            Debug.Log("Answer creation failed!. Error: " + www.error);
        }
    }

    public void VerifyInputQ()
    {
        submitButtonQ.interactable = (questionField.text.Length >= 10);
    }
    public void VerifyInputA()
    {
        submitButtonA.interactable = (answerField.text.Length >= 10);
    }


}
