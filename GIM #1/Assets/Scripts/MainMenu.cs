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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("LevelSelection");
            }
        }

    }
}

