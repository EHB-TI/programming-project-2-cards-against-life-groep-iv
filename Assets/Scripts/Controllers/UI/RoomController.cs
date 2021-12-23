using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RoomController : MonoBehaviour, IPointerClickHandler
{
    public RoomAPIController roomAPI;
    public TabGroup tabGroup1;
    public TabGroup tabGroup2;
    public GameObject BtnPreFab;
    public Transform panel;

    public void showRooms(List<Room> rooms)
    {
        int posX = 0;
        
        foreach (Room r in rooms)
        {
            if (r.pub == 1) //When room is public
            {
                //Make room buttons
                GameObject GoBtn = Instantiate(BtnPreFab, panel.transform);
                GoBtn.SetActive(true);
                GoBtn.transform.SetParent(panel.transform, true);
                Vector3 pos = GoBtn.transform.position;

                GoBtn.transform.position = new Vector3(pos.x + posX, pos.y);
                GoBtn.GetComponentInChildren<TextMeshProUGUI>().SetText("Room " + r.room_id);
                posX += 100;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        roomAPI.MakeRoom(OpenClosedCheck(tabGroup1.selectedTab), tabGroup2.selectedTab.id);
    }

    public List<Room> getAllRooms(List<Room> rooms)
    {
        return rooms;
    }

    public int OpenClosedCheck(TabButton tab1)
    {
        int open = tab1.id;
        switch (tab1.id)
        {
            case 0:
                open = 1; // open 
                break;
            case 1:
                open = 0; // closed 
                break;
        }
        return open;
    }


}

