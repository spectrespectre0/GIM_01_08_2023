using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public NewBehaviourScript NBS;
    //public GameObject UIrestart;
    
    public void onclick()
    {
        NBS.OnRestartButton();
    }
}
