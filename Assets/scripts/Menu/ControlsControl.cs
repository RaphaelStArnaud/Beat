using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlsControl : MonoBehaviour {
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        EventSystem.current.SetSelectedGameObject(GameObject.Find("ReturnToMainMenuButton"), new BaseEventData(EventSystem.current));

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Submit") || Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("menuPrincipal");
            GameManager.menuMusicTime = audio.time;
        }

    }
}
