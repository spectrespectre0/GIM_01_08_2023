using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    public string status;

    public void easy()
    {
        SceneManager.LoadScene("EasyLevel");
        status = "EasyLevel";
    }
    public void medium()
    {
        SceneManager.LoadScene("MedLevel");
        status = "MedLevel";
    }

    public void hard()
    {
        SceneManager.LoadScene("HardLevel");
        status = "HardLevel";
    }

    void Update()
    {
        
    }
}
