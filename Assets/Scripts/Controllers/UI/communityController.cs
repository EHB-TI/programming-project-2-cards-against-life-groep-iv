using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class communityController : MonoBehaviour
{

    public GameObject BtnPreFab;
    public Transform panel;

    public void showQuestions(List<Community> questions)
    {
        Debug.Log(questions[0].questions);


        GameObject clickBtn = Instantiate(BtnPreFab, panel.transform);
        clickBtn.SetActive(true);
        clickBtn.transform.SetParent(panel.transform, false);


        clickBtn.GetComponentInChildren<Text>().text = "bla";

    }

   
   


}


