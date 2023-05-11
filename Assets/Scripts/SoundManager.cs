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
        audio.loop = true;

    }
    void Start () {
        DontDestroyOnLoad(gameObject.transform);
    }
    public void DestThis()
    {
        audio.Pause();
    }
    public void mainBMG()
    {
        audio.clip = mainBGM;
        audio.volume = 0.5f;
        audio.Play();
    }
    public void setPay()
    {
        audio.UnPause();
    }
}
