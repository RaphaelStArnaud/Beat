using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour {
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        audio.Stop();
        audio.time = GameManager.menuMusicTime;
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
