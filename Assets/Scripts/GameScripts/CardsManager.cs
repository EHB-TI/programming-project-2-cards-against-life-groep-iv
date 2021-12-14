using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardsManager : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update

    Card2 [] cards;
    public Button[] buttons;
    public int clicked;
    void Start()
    {
        cards = new Card2[4];
        //cards[0] = ??
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteCard1(int id)
    {
       // cards[0] = new Card2(id, sentence);
    }
    

    public void test(int id)
    {
        clicked = id;
       // buttons[id].
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
    }
}
