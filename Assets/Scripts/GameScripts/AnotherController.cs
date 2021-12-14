using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnotherController : MonoBehaviour
{
    public static AnotherController instance;
    //public List<Card> cards = new List<Card>();
    public Card[] cards;
   // public Transform pos1, pos2, pos3,pos4;
    public Transform [] positions;
    public AnotherScript [] cardControllerPrefab;
    public int selection;

    public GameObject prefabs;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        cards = new Card [4];
        GenerateCards();
    }

    private void GenerateCards()
    {
       for (int i = 0; i< positions.Length; i++)
        {
            // AnotherScript newcard = Instantiate(cardControllerPrefab, positions[i]);

            //get card From API!!!
            Card card = new Card();
            cardControllerPrefab[i].card = card;
            Debug.Log("created: " + i);


          //  newcard.transform.localPosition = Vector3.zero;
           // Card card = new Card();
         //   newcard.initialize(card);
            cards[i] = card;
        }
    }

    public void selectCard(int number)
    {
        Debug.Log("Selected " + number);
        selection = number;
    }

    public void finalSelection()
    {
        Debug.Log("U HAVE SELECTED: " + selection);
    }
}
