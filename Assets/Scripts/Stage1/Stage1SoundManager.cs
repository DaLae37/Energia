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
        audio.clip = bgm;
        audio.Play();
        audio.loop = true;
    }
    public void space()
    {
        audio.PlayOneShot(spaceShip);
    }
}
