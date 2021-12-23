using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public List<Card> cards = new List<Card>();
    public Transform player1, player2;
    public CardController cardControllerPrefab; 

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateCards();
    }

    private void GenerateCards()
    {
        foreach(Card card in cards)
        {
            CardController newcard = Instantiate(cardControllerPrefab, player1);
            newcard.transform.localPosition = Vector3.zero;
            newcard.initialize(card);
        }
    } 
}
