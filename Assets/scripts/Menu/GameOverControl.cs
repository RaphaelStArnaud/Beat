using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour {
    public Text song, difficulty, score;
    private ArrayList scenes;
    private ArrayList buttons;
    private int index = 0;
    private float cdMove = 0;


    // Use this for initialization
    void Start () {
        scenes = new ArrayList { "Loading", "MenuPrincipal"};
        buttons = new ArrayList { "Retry", "MainMenu"};

        song.text = GameManager.song;
        difficulty.text = GameManager.difficulty.ToString();
        score.text = GameManager.score.ToString();

        GameManager.menuMusicTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (cdMove > 0)
        {
            cdMove -= Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") != 0 && cdMove <= 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                index--;

                if (index < 0)
                    index = buttons.Count - 1;
            }
            else
            {
                index++;

                if (index > buttons.Count - 1)
                    index = 0;
            }


            string selected = (string)buttons[index];
            EventSystem.current.SetSelectedGameObject(GameObject.Find(selected), new BaseEventData(EventSystem.current));

            cdMove = 0.2f;
        }

        if (Input.GetButton("Submit"))
        {
            string selected = (string)scenes[index];
            SceneManager.LoadScene(selected);
        }

    }
}
