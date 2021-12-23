using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class startscene : MonoBehaviour
{

    public void goToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
