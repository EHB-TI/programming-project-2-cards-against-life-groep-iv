using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class tabButton : MonoBehaviour, IPointerClickHandler
{
    public tabGroup tabGroup;

    public Image background { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
    }

}
