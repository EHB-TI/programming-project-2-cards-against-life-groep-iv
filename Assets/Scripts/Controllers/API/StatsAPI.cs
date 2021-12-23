using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

[System.Serializable]
public class StatsAPI : MonoBehaviour
{
    public UserData userData;
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://test-api-vougel.herokuapp.com/stats");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
          //  Debug.Log(request.downloadHandler.text);
            StatsData stats = JsonConvert.DeserializeObject<StatsData>(request.downloadHandler.text);
            getStatsById(stats);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
        
    }
    
   /* public void getStats(StatsData stats)
    {
        Debug.Log(stats.Stats);

        foreach (Stats x in stats.Stats)
        {
            Debug.Log(x.games_lost);
            Debug.Log(x.games_won);
            Debug.Log(x.games_played);
        }
    }*/
    public void getStatsById(StatsData stats)
    {
        
        foreach (Stats x in stats.Stats)
        {
            if (x.id_user == 2)
            {


                Debug.Log(x.games_lost);
                Debug.Log(x.games_won);
                Debug.Log(x.games_played);
            }
        }
    }


}
