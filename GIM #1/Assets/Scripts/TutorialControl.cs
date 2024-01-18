using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{
    public TextMeshProUGUI TopControl;
    public string top1;
    public string top2;
    public string top3;
    public string bot1;
    public string bot2;
    public string bot3;
    public TextMeshProUGUI BotControl;
    // Start is called before the first frame update

    void Start()
    {
        top1 = PlayerPrefs.GetString("p11", KeyCode.Z.ToString());
        top2 = PlayerPrefs.GetString("p12", KeyCode.X.ToString());
        top3 = PlayerPrefs.GetString("p13", KeyCode.C.ToString());
        bot1 = PlayerPrefs.GetString("p21", KeyCode.B.ToString());
        bot2 = PlayerPrefs.GetString("p22", KeyCode.N.ToString());
        bot3 = PlayerPrefs.GetString("p23", KeyCode.M.ToString());
        TopControl.text =  top1 + " , " + top2 + " , " + top3;
        BotControl.text = bot1 + " , " + bot2 + " , "+ bot3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
