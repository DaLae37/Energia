using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainSceneManager : MonoBehaviour {
    // Use this for initialization
    void Start () {
        SoundManager.instance.mainBMG();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }
}
