using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class RAPI : MonoBehaviour
{
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://test-api-vougel.herokuapp.com/r");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            RData rdata = JsonConvert.DeserializeObject<RData>(request.downloadHandler.text);
            getRData(rdata);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }

    public void getRData(RData cards)
    {
        Debug.Log(cards.R.Answers[0].value);

        Debug.Log(cards.R.Questions[0].value);
    }
}
