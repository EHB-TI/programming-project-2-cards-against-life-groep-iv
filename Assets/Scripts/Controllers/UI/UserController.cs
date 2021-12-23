using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    public GameObject BtnPreFab;
    public Transform panel;

    public void showUsers(List<User> users)
    {
        Debug.Log(users[0].username);

       
        GameObject clickBtn = Instantiate(BtnPreFab, panel.transform);
        clickBtn.SetActive(true);
        clickBtn.transform.SetParent(panel.transform, false);

        clickBtn.GetComponentInChildren<Text>().text = "bla";

     

       
    }
}
