using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class SettingsButtons : MonoBehaviour
{
    public KeyCode change;
    public string change_str;
    public GameObject p1;
    public GameObject p2;
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
                            nbs1.keycode_space_1 = change;
                            break;
                        case 2:
                            p1_2.text = change.ToString();
                            nbs1.keycode_space_2 = change;
                            break;
                        case 3:
                            p1_3.text = change.ToString();
                            nbs1.keycode_space_3 = change;
                            break;
                        case 4:
                            p2_1.text = change.ToString();
                            nbs2.keycode_space_1 = change;
                            break;
                        case 5:
                            p2_2.text = change.ToString();
                            nbs2.keycode_space_2 = change;
                            break;
                        case 6:
                            p2_3.text = change.ToString();
                            nbs2.keycode_space_3 = change;
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
