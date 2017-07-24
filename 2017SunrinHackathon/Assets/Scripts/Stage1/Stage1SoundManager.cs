using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1SoundManager : MonoBehaviour {
    public AudioSource audio;
    public AudioClip bgm;
    public AudioClip spaceShip;
	// Use this for initialization
	void Start () {
        audio = gameObject.AddComponent<AudioSource>();
	}
	public void BGM()
    {
        audio.volume = 0.05f;
        audio.clip = bgm;
        audio.Play();
    }
    public void space()
    {
        audio.clip = spaceShip;
        audio.volume = 1.0f;
        audio.Play();
    }
}
