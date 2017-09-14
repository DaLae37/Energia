using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSceneManager : MonoBehaviour {
    public static StageSceneManager instance;
	// Use this for initialization
	void Start () {
        instance = this;
	}
    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }
    public void ReRoad1()
    {
        PlayerPrefs.SetInt("coal", PlayerControl.instance.coal);
        PlayerPrefs.SetInt("petroleum", PlayerControl.instance.petroleum);
        SceneManager.LoadScene("Stage1");
    }
    public void ReRoad2()
    {
        PlayerPrefs.SetInt("coal", PlayerControl.instance.coal);
        PlayerPrefs.SetInt("petroleum", PlayerControl.instance.petroleum);
        SceneManager.LoadScene("Stage1");
    }
    public void ReRoad3()
    {
        PlayerPrefs.SetInt("coal", PlayerControl.instance.coal);
        PlayerPrefs.SetInt("petroleum", PlayerControl.instance.petroleum);
        SceneManager.LoadScene("Stage1");
    }
}
