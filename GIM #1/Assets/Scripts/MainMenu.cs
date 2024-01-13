using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

    //public void PlayGame()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //}

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("LevelSelection");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

