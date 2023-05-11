using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage2 : MonoBehaviour
{
    public static Stage2 instance;
    public Text Ura;
    public int index = 0;
    public int[] StageList = { 2, 2, 1, 1, 0, 1, 2, 1, 2, 1, 2, 2, 2, 0, 1, 1, 2, 1, 0 };
    public bool gameOver;
    private void Awake()
    {
        index = 0;
        gameOver = false;
        instance = this;
    }
    private void Update()
    {
        Ura.text = " : " + PlayerControl2.instance.ura.ToString();
    }
}
