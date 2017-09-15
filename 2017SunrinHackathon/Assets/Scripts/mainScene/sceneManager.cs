using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour {
    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }

    public void deliveryScene()
    {
        SceneManager.LoadScene("miniGame");
    }
}
