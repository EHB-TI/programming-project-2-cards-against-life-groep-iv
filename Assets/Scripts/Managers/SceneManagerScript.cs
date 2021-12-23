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
        foreach (TabButton button in selectedtabs)
        {
            // Debug.Log(button);
            if (button.name.Equals("BtnOpen"))
            {
                SceneManager.LoadScene(7);
            }
            if (button.name.Equals("BtnClosed"))
            {
                SceneManager.LoadScene(6);
            }
        }
    }
    public void OpenScene(int scene)
    {
        //Hier komt switch case adhv openScene() integer parameter
        switch (scene)
        {
            case 0:
                SceneManager.LoadScene(0);
                break;
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            case 4:
                SceneManager.LoadScene(4);
                break;
            case 5:
                SceneManager.LoadScene(5);
                break;
            case 6:
                SceneManager.LoadScene(6);
                break;
            case 7:
                SceneManager.LoadScene(7);
                break;
            case 8:
                SceneManager.LoadScene(8);
                break;
            case 9:
                SceneManager.LoadScene(9);
                break;
        }
    }

    public void quit ()
    {
        Application.Quit();
    }
}
