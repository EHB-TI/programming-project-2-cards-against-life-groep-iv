using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    public TabGroup TabGroup1;
    public TabGroup TabGroup2;

    public List<TabButton> selectedtabs;
    public void Selected()
    {
        selectedtabs = new List<TabButton>();
        selectedtabs.Add(TabGroup1.selectedTab);
        selectedtabs.Add(TabGroup2.selectedTab);
    }

    public void OpenScene()
    {
        Selected();

        foreach(TabButton button in selectedtabs)
        {
            Debug.Log(button);
            if (button.name.Equals("BtnOpen")){
                SceneManager.LoadScene(1);
            }
           if(button.name.Equals("BtnClosed")){
                SceneManager.LoadScene(2);
            }
        } 
    }
}
