using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;


public class PG13API : MonoBehaviour
{
    CardPG13Data card;
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://test-api-vougel.herokuapp.com/pg13");
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log(request.downloadHandler.text);
            CardPG13Data CardPG13 = JsonConvert.DeserializeObject<CardPG13Data>(request.downloadHandler.text);
            card = CardPG13;
            getPG13Cards(CardPG13);
        }
        else
        {
            Debug.Log("Something went wrong");
        }  
    }

    public void getPG13Cards(CardPG13Data cards)
    {
        Debug.Log(cards.PG13.answers[0].answer);

        Debug.Log(cards.PG13.questions[0].question);

        Debug.Log("random card:::: " + randomCard());

        /* foreach (Data x in rooms.data)
         {
             Debug.Log(x.code);
         }*/
    }

    public string randomCard()
    {
        string newcard = "";

        int rand = (int)Random.RandomRange(0.1f, 2.99f);

        Debug.Log("rand es " + rand);

        Debug.Log("lo otro: " + card.PG13.answers[0].answer);
        
        newcard = card.PG13.answers[rand].answer;

        return newcard;
    }

    public string randomQuestion()
    {/*
        string newcard = "";
        UnityWebRequest request = UnityWebRequest.Get("https://test-api-vougel.herokuapp.com/pg13");

        try
        {
            CardPG13Data CardPG13 = JsonConvert.DeserializeObject<CardPG13Data>(request.downloadHandler.text);
            int rand = (int)Random.RandomRange(1.0f, 1.0f);
            newcard = CardPG13.PG13.questions[rand].question;
        }
        catch
        {
            newcard = "Error: please revise your internet connection";
        }

        return newcard;
    }
        */
        string newcard = "";

        int rand = (int)Random.RandomRange(0.1f, 2.99f);

        newcard = card.PG13.questions[rand].question;

        return newcard;
    }
}


