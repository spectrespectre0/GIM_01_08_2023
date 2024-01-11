using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    public NewBehaviourScript audioref;

    public void Pause()
    {
      
      pauseMenu.SetActive(true);
      pauseButton.SetActive(false);
      Time.timeScale = 0;
      Pausemusic();
      
    }
    public void Resume()
    {
      pauseMenu.SetActive(false);
      pauseButton.SetActive(true);
        Time.timeScale = 1;
        UnPausemusic();
    } 
    public void Goback()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1; 
    }

    public void Pausemusic()
    {
        audioref.playerAudioSource.Pause();
    }

    public void UnPausemusic()
    {
       audioref.playerAudioSource.UnPause();
    }
}
