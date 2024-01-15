using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class SettingsButtons : MonoBehaviour
{
    public KeyCode change;
    public string change_str;
    public NewBehaviourScript nbs1;
    public NewBehaviourScript nbs2;
    public TextMeshProUGUI p1_1;
    public TextMeshProUGUI p1_2;
    public TextMeshProUGUI p1_3;
    public TextMeshProUGUI p2_1;
    public TextMeshProUGUI p2_2;
    public TextMeshProUGUI p2_3;
    public bool clickstatus;
    public int assign;

    private void Start()
    {
        assign = 1;
        clickstatus = false;
        p1_1.text = PlayerPrefs.GetString("p11", KeyCode.Z.ToString());
        p1_2.text = PlayerPrefs.GetString("p12", KeyCode.X.ToString());
        p1_3.text = PlayerPrefs.GetString("p13", KeyCode.C.ToString());
        p2_1.text = PlayerPrefs.GetString("p21", KeyCode.B.ToString());
        p2_2.text = PlayerPrefs.GetString("p22", KeyCode.N.ToString());
        p2_3.text = PlayerPrefs.GetString("p23", KeyCode.M.ToString());
    }
    
    private void Update()
    {
        if (clickstatus)
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    change = keycode;
                    Debug.Log(change);
                    clickstatus = false;
                    switch (assign)
                    {
                        case 1:
                            p1_1.text = change.ToString();
                            PlayerPrefs.SetString("p11", p1_1.text);
                            PlayerPrefs.SetInt("p1_1", (int)change);
                            break;
                        case 2:
                            p1_2.text = change.ToString();
                            PlayerPrefs.SetString("p12", p1_2.text);
                            PlayerPrefs.SetInt("p1_2", (int)change);
                            break;
                        case 3:
                            p1_3.text = change.ToString();
                            PlayerPrefs.SetString("p13", p1_3.text);
                            PlayerPrefs.SetInt("p1_3", (int)change);
                            break;
                        case 4:
                            p2_1.text = change.ToString();
                            PlayerPrefs.SetString("p21", p2_1.text);
                            PlayerPrefs.SetInt("p2_1", (int)change);
                            break;
                        case 5:
                            p2_2.text = change.ToString();
                            PlayerPrefs.SetString("p22", p2_2.text);
                            PlayerPrefs.SetInt("p2_2", (int)change);
                            break;
                        case 6:
                            p2_3.text = change.ToString();
                            PlayerPrefs.SetString("p23", p2_3.text);
                            PlayerPrefs.SetInt("p2_3", (int)change);
                            break;
                    }

                }
            }
        }
    }

    public void p1_keycode1()
    {
        clickstatus = true;
        assign = 1;
    }
    public void p1_keycode2()
    {
        clickstatus = true;
        assign = 2;
    }
    public void p1_keycode3()
    {
        clickstatus = true;
        assign = 3;
    }
    public void p2_keycode1()
    {
        clickstatus = true;
        assign = 4;
    }
    public void p2_keycode2()
    {
        clickstatus = true;
        assign = 5;

    }
    public void p2_keycode3()
    {
        clickstatus = true;
        assign = 6;
    }
}
