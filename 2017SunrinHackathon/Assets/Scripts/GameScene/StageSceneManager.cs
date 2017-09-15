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
    public void Clear1selectScene()
    {
        PlayerPrefs.SetInt("coal", PlayerPrefs.GetInt("coal") + PlayerControl.instance.coal);
        PlayerPrefs.SetInt("petroleum", PlayerPrefs.GetInt("petroleum") + PlayerControl.instance.petroleum);
        PlayerPrefs.SetInt("Stage1", 1);
        SoundManager.instance.setPay();
        SceneManager.LoadScene("selectScene");
    }
    public void Clear2selectScene()
    {
        PlayerPrefs.SetInt("ura", PlayerPrefs.GetInt("ura") + PlayerControl2.instance.ura);
        PlayerPrefs.SetInt("Stage2", 1);
        SoundManager.instance.setPay();
        SceneManager.LoadScene("selectScene");
    }
    public void Clear3selectScene()
    {
        PlayerPrefs.SetInt("hydro", PlayerPrefs.GetInt("hydro") + PlayerControl3.instance.hydro);
        PlayerPrefs.SetInt("Stage3", 1);
        SoundManager.instance.setPay();
        SceneManager.LoadScene("selectScene");
    }
    public void selectScene1()
    {
        PlayerPrefs.SetInt("coal", PlayerPrefs.GetInt("coal") + PlayerControl.instance.coal);
        PlayerPrefs.SetInt("petroleum", PlayerPrefs.GetInt("petroleum") + PlayerControl.instance.petroleum);
        SoundManager.instance.setPay();
        SceneManager.LoadScene("selectScene");
    }
    public void selectScene2()
    {
        PlayerPrefs.SetInt("ura", PlayerPrefs.GetInt("ura") + PlayerControl2.instance.ura);
        SoundManager.instance.setPay();
        SceneManager.LoadScene("selectScene");
    }
    public void selectScene3()
    {
        PlayerPrefs.SetInt("hydro", PlayerPrefs.GetInt("hydro") + PlayerControl3.instance.hydro);
        SoundManager.instance.setPay();
        SceneManager.LoadScene("selectScene");
    }
    public void ReRoad1()
    {
        PlayerPrefs.SetInt("coal", PlayerPrefs.GetInt("coal") + PlayerControl.instance.coal);
        PlayerPrefs.SetInt("petroleum", PlayerPrefs.GetInt("petroleum") + PlayerControl.instance.petroleum);
        SceneManager.LoadScene("Stage1");
    }
    public void ReRoad2()
    {
        PlayerPrefs.SetInt("ura", PlayerPrefs.GetInt("ura") + PlayerControl2.instance.ura);
        SceneManager.LoadScene("Stage2");
    }
    public void ReRoad3()
    {
        PlayerPrefs.SetInt("hydro", PlayerPrefs.GetInt("hydro") + PlayerControl3.instance.hydro);
        SceneManager.LoadScene("Stage3");
    }
}
