using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class selectSceneManager : MonoBehaviour {
    private void Start()
    {
        SoundManager.instance.mainBMG();
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
        SceneManager.LoadScene("Stage1");
    }
    public void stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
}
