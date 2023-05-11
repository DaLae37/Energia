using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage3 : MonoBehaviour
{
    public static Stage3 instance;
    public Text Hydro;
    public int index = 0;
    public int[] StageList = { 2, 0, 2, 1, 1, 0, 1, 2, 1, 2, 2, 1, 2, 1, 2, 1, 2, 0, 1, 0 };
    public bool gameOver;
    private void Awake()
    {
        index = 0;
        gameOver = false;
        instance = this;
    }
    private void Update()
    {
        Hydro.text = " : " + PlayerControl3.instance.hydro.ToString();
    }
}
