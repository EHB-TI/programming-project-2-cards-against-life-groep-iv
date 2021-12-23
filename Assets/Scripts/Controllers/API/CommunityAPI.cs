
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class CommunityAPI : MonoBehaviour
{
    public communityController communityController;
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://test-api-vougel.herokuapp.com/community");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            CommunityData communityData = JsonConvert.DeserializeObject<CommunityData>(request.downloadHandler.text);
            communityController.showQuestions(communityData.communities);
            getCommunityData(communityData);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }
    // get all community data from database
    public void getCommunityData(CommunityData cards)
    {
        Debug.Log(cards.Community.answers[0].answer);

        Debug.Log(cards.Community.questions[0].question);
    }
}
