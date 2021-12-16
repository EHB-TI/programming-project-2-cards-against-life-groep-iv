using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    public GameObject menu1;
    public GameObject menu2;

    private void Awake()
    {
        //ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();

        button.background.color = Color.gray;

 // beter uitdenken
        if (selectedTab.name.Equals("BtnHost")
            || selectedTab.name.Equals("BtnOpen") || selectedTab.name.Equals("BtnClosed")
            || selectedTab.name.Equals("BtnPG") || selectedTab.name.Equals("BtnPG13")
            || selectedTab.name.Equals("BtnRRated") || selectedTab.name.Equals("BtnCommunity"))
        {
            menu1.SetActive(true);
            ButtonMakeRoom.opties.Add(button.name);
            ButtonMakeRoom.ShowOptions();
        } else{
            menu1.SetActive(false);
            menu2.SetActive(false);
            ResetTabs();
        }

        if(selectedTab.name.Equals("BtnPrivate")){
            menu1.SetActive(false);
            menu2.SetActive(true);
            }
        else{
            menu2.SetActive(false);
            ResetTabs();
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
            { continue; }
            button.background.color = Color.white;
        }
    }
}
