using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour {
    public int speed = 7;
    public float change;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.alive)
        {
            Transform player = GameObject.Find("Player").GetComponent<Transform>();
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;
        }  
    }

    public void death() { 
        AudioSource audio = (AudioSource) GameObject.Find("Main Camera").GetComponent<AudioSource>();

        if(change >=0 && audio.pitch < 1.5)
            GameObject.Find("Main Camera").GetComponent<AudioSource>().pitch += change;
        else if(change < 0 && audio.pitch > 0.5)
            GameObject.Find("Main Camera").GetComponent<AudioSource>().pitch += change;

        GameObject.Find("PitchValue").GetComponent<Text>().text = ((int)(audio.pitch * 100)) + "%";
    }
    
}
