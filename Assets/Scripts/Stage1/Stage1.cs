using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage1 : MonoBehaviour {
    
    public static Stage1 instance;
    public Text Coal;
    public Text Petroleum;
    public int index = 0;
    public int[] StageList = { 2, 1, 2, 2, 1, 1, 2, 1, 0, 1,2,1,2,2,1,0,2,0,1,1,1,2,2,0};
    public bool gameOver;
    private void Awake()
    {
        index = 0;
        gameOver = false;
        instance = this;
    }
    private void Start()
    {

    }
    private void Update()
    {
        Coal.text = " : " + PlayerControl.instance.coal.ToString();
        Petroleum.text = " : " + PlayerControl.instance.petroleum.ToString();
    }
}
