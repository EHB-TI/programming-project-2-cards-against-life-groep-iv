using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems; 

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public Card card;
    public Image illustration;
    public TextMeshProUGUI cardName, description;


    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void initialize(Card card)
    {
        this.card = card;
        illustration.sprite = card.illustration;
        cardName.text = card.cardName;
        description.text = card.description;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("entered");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }
}
