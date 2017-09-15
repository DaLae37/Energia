using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deliverySceneManager : MonoBehaviour {
    public GameObject Developer;
    public GameObject FailPop;
    public GameObject SuccessPop;
    public GameObject Stage1Clear;
    public GameObject Stage2Clear;
    public GameObject Stage3Clear;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("Stage3Clear") == 1)
            Stage3Clear.SetActive(true);
        if (PlayerPrefs.GetInt("Stage2Clear") == 1)
            Stage2Clear.SetActive(true);
        if (PlayerPrefs.GetInt("Stage1Clear") == 1)
            Stage1Clear.SetActive(true);
	}
    public void backScene()
    {
        SceneManager.LoadScene("miniGame");
    }
    public void unHideDeveloper()
    {
        Developer.SetActive(true);
    }
    public void HideDeveloper()
    {
        Developer.SetActive(false);
    }
    public void Stage1Delivery()
    {
        if (!Stage1Clear.activeSelf)
        {
            int c = PlayerPrefs.GetInt("coal");
            int p = PlayerPrefs.GetInt("petroleum");
            if (PlayerPrefs.GetInt("Stage1") == 1 && c >= 50 && p >= 50)
            {
                SuccessPop.SetActive(true);
                Stage1Clear.SetActive(true);
                PlayerPrefs.SetInt("coal", c - 50);
                PlayerPrefs.SetInt("Stage1Clear", 1);
            }
            else
                FailPop.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Stage1Ending");
        }
    }
    public void Stage2Delivery()
    {
        if (!Stage2Clear.activeSelf)
        {
            int u = PlayerPrefs.GetInt("ura");
            if (PlayerPrefs.GetInt("Stage2") == 1 && u >= 50)
            {
                SuccessPop.SetActive(true);
                Stage2Clear.SetActive(true);
                PlayerPrefs.SetInt("Stage2Clear", 1);
            }
            else
                FailPop.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Stage2Ending");
        }
    }
    public void Stage3Delivery()
    {
        if (!Stage3Clear.activeSelf)
        {
            int h = PlayerPrefs.GetInt("hydro");
            if (PlayerPrefs.GetInt("Stage3") == 1 && h >= 50)
            {
                SuccessPop.SetActive(true);
                Stage3Clear.SetActive(true);
                PlayerPrefs.SetInt("Stage3Clear", 1);
            }
            else
                FailPop.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Stage3Ending");
        }
    }
    public void HideSuccess()
    {
        SuccessPop.SetActive(false);
    }
    public void HideFail()
    {
        FailPop.SetActive(false);
    }
}
