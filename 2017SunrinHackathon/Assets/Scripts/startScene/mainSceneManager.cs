using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainSceneManager : MonoBehaviour {
    // Use this for initialization
    void Start () {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
        SoundManager.instance.mainBMG();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
}
