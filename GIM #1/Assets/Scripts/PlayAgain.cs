using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update

    public LevelSelect ls;
    public string stat;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onclick()
    {
        stat = ls.status;
        SceneManager.LoadScene(stat);
    }

    public void homeclick()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
