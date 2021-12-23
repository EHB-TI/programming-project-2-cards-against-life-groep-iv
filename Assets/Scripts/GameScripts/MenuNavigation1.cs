using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation1 : MonoBehaviour
{
    //Author: De Vogel Ryan
    //source: https://www.youtube.com/watch?v=SKbY-0zt2VE&t=141s It's a serie

    public Text playerDisplay;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = DBManager.username + " logged in!";
        }
    }

    // Start is called before the first frame update
    public void GoToRegister()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToMenuScene()
    {
        if (DBManager.LoggedIn == true)
        {
            SceneManager.LoadScene(4);
        }
    }
}
