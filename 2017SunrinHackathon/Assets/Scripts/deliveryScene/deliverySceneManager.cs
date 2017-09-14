using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverySceneManager : MonoBehaviour {
    public GameObject Developer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unHideDeveloper()
    {
        Developer.SetActive(true);
    }
    public void HideDeveloper()
    {
        Developer.SetActive(false);
    }
}
