using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : MonoBehaviour
{
    //store the card front and back sprites, located in the inspector
    //public Sprite CardFront;
    // public Sprite CardBack;
    public Text text;
    private bool isHost;

    public void Flip(string caller)
    {
        //when Flip() is called, store the value of the current sprite attached to this gameobject
        Sprite currentSprite = gameObject.GetComponent<Image>().sprite;
        Text currentText = gameObject.GetComponent<Text>();

        //conditional logic to determine whether to display the card front or back sprite
        /*if (currentSprite == CardFront)
        {
            gameObject.GetComponent<Image>().sprite = CardBack;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
        */
        Debug.Log("FLIPPING");

        if (caller == "host")
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            Debug.Log("host");
           // gameObject.GetComponent<Text>().gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("player");
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            // gameObject.GetComponent<Text>().text = "waiting for player";
        }


    }
}