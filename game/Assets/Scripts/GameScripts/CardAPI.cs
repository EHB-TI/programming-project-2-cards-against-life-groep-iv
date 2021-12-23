using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class CardAPI : MonoBehaviour
{
    /*
    // Start is called before the first frame updateç

    public string path;

    public string jsonString;


    public GameObject json;
    public InputJson exe = new InputJson();

    // Use this for initialization
  
    [System.Serializable]
    public class InputJson
    {
        public List<int> Grid_1;
    }

    IEnumerator Start()
    {
        path = Application.streamingAssetsPath + "/json1.json";
        jsonString = File.ReadAllText(path);
        exe = JsonUtility.FromJson<InputJson>(jsonString);
        Debug.Log("getting in URL");
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/pg13");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            CardsJson cardspg = JsonConvert.DeserializeObject<CardsJson>(jsonString);
        else
            {
                Debug.Log("Something went wrong");
            }
            Debug.Log(request.error);

        }
    }

  
    public void getCards(CardsJson cards)
    {
        Debug.Log(cards);

        foreach (CardsJson.Answer x in cards.answers)
        {
            Debug.Log(x);
        }
      
    }

    [System.Serializable]
    private struct JsonArrayWrapper<T>
    {
        public T wrap_result;
    }

    public static T ParseJsonArray<T>(string json)
    {
        var temp = JsonUtility.FromJson<JsonArrayWrapper<T>>("{\"wrap_result\":" + json + "}");
        return temp.wrap_result;
    }
    */
}
