using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage2EndingSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (PlayerPrefs.GetInt("Stage1Clear") == 1 && PlayerPrefs.GetInt("Stage2Clear") == 1 && PlayerPrefs.GetInt("Stage3Clear") == 1)
            {
                SceneManager.LoadScene("endingScene");
            }
            else
            {
                SceneManager.LoadScene("deliveryScene");
            }
        }
    }
}
