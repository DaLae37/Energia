using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class miniGameSceneManager : MonoBehaviour {
    public Image Coal;
    public Image Petronum;
    public Image Hydro;
    public Image Ura;
    public Text Coal_T;
    public Text Petronum_T;
    public Text Hydro_T;
    public Text Ura_T;

    public GameObject resetPOP;
	// Use this for initialization
	void Start () {
        int c = PlayerPrefs.GetInt("coal");
        int p = PlayerPrefs.GetInt("petroleum");
        int h = PlayerPrefs.GetInt("hydro");
        int u = PlayerPrefs.GetInt("ura");
        Coal.fillAmount = (float)(c / 50f);
        Coal_T.text = c + "";
        Petronum.fillAmount = (float)(p / 50f);
        Petronum_T.text = p + "";
        Hydro.fillAmount = (float)(h / 50f);
        Hydro_T.text = h + "";
        Ura.fillAmount = (float)(u / 50f);
        Ura_T.text = u + "";
	}
    public void Delivery()
    {
        SceneManager.LoadScene("deliveryScene");
    }
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Destroy(SoundManager.instance.gameObject);
        SceneManager.LoadScene("startScene");
    }
    public void unHideReset()
    {
        resetPOP.SetActive(true);
    }
    public void HideReset()
    {
        resetPOP.SetActive(false);
    }
}
