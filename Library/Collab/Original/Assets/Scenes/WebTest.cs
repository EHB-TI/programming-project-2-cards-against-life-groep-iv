using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/sqlconnect/webtest.php");
        yield return request.SendWebRequest();
        string[] webResult = request.downloadHandler.text.Split('\t');
        foreach (string s in webResult)
        {
            Debug.Log(s);
        }
    }

 
}
