using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class communityController : MonoBehaviour
{

    public GameObject BtnPreFab;
    public Transform panel;

    public void showRooms(List<Community> questions)
    {
        Debug.Log(questions[0].questions);

        /*foreach(Room r in rooms) { 
          Debug.Log(r.id);
        } */

        GameObject clickBtn = Instantiate(BtnPreFab, panel.transform);
        clickBtn.SetActive(true);
        clickBtn.transform.SetParent(panel.transform, false);

        // GoBtn.GetComponent<Image>().color = Color.black;

        clickBtn.GetComponentInChildren<Text>().text = "bla";

        // string var =  GoBtn.transform.Find("room 1");

        foreach (Community c in questions)
        {
            //buttonList[i].gameobject.GetComponentInParent<BoardPiece>();
        }

        // btn.transform.position = new Vector3(0, 0);

        //Vector3.zero;
    }

   
   


}


