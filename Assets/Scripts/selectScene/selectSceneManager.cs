using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class selectSceneManager : MonoBehaviour {
    private void Start()
    {

    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                mainScene();
            }
        }
    }
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void stage1()
    {
        SoundManager.instance.DestThis();
        SceneManager.LoadScene("Stage1");
    }
    public void stage2()
    {
        SoundManager.instance.DestThis();
        SceneManager.LoadScene("Stage2");
    }
    public void stage3()
    {
        SoundManager.instance.DestThis();
        SceneManager.LoadScene("Stage3");
    }
}
