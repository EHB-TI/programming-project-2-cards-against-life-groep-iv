
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class PGAPI : MonoBehaviour
{
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/PG");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            PGData pgdata = JsonConvert.DeserializeObject<PGData>(request.downloadHandler.text);
            getPGData(pgdata);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }

    public void getPGData(PGData cards)
    {
        Debug.Log(cards.PG.answers[0].answer);

        Debug.Log(cards.PG.questions[0].question);
    }
}
