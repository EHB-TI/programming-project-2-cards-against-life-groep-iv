using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    public GameObject hostMenu;

    private void Awake()
    {
        ResetTabs();
    }

    public void Subscribe(TabButton button)
    {
        ResetTabs();
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();

       button.background.color = Color.gray;

        if(selectedTab.name.Equals("BtnHost") || selectedTab.name.Equals("BtnOpen") || selectedTab.name.Equals("BtnClosed"))
        {
            hostMenu.SetActive(true);
        }
        else
        {
            hostMenu.SetActive(false);
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
