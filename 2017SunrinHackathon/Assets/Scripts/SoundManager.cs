using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
    public AudioSource audio;
    public AudioClip mainBGM;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
        audio = gameObject.AddComponent<AudioSource>();

    }
    void Start () {

	}
	
	public void mainBMG() { 
        audio.clip = mainBGM;
        audio.Play();
	}
    public void SceneChange()
    {
        audio.Pause();
        DontDestroyOnLoad(transform.gameObject);
    }
    public void reStart()
    {
        audio.Play();
    }
}
