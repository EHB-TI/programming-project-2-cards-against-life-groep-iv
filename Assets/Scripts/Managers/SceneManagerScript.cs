using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    public void OpenScene(int scene)
    {
      
        SceneManager.LoadScene(scene);

    }


}
