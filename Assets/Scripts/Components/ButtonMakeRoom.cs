using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMakeRoom : MonoBehaviour
{
    public static List<string> opties = new List<string>(); 

    public static void ShowOptions()
    {
        foreach(string optie in opties)
        {
Debug.Log(optie);
        }
        
    }
}
