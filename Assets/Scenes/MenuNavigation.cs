using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
   public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
