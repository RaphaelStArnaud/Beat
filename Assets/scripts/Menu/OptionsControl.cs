using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsControl : MonoBehaviour {
    public Text txtDiff;
    public Text txtSong;
    public Text labelDiff;
    public Text labelSong;
    public AudioSource audio;


    private ArrayList lstOptions = new ArrayList{"txtDiff","txtMusic","btnSubmit", "btnCancel"};
    private int difficulty;
	private ArrayList lstMusic = new ArrayList{"Furious Freak","Laser Groove","Latin Industries", "Special Spotlight"};
    private Text txtMusic;
    private Text txtDifficulty;
    private float cdMove = 0;
    private float cdMoveH = 0;
    private int index = 0;
	private int musicIndex = 0;
	private string song;
		
	//necessaire pour naviguer dans la liste de chanson
	private int indexMusic = 0;
	
    void Start () {
        difficulty = GameManager.difficulty;
        song = GameManager.song;

        txtDiff.text = difficulty.ToString();
        txtSong.text = song;

        musicIndex = lstMusic.IndexOf(song);
	}

	// Update is called once per frame
	void Update () {
		if(cdMove > 0)
        {
            cdMove -= Time.deltaTime;
        }

        if (cdMoveH > 0)
        {
            cdMoveH -= Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") != 0 && cdMove <= 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                index--;

                if (index < 0)
                    index = lstOptions.Count - 1;
            }
            else
            {
                index++;

                if (index > lstOptions.Count - 1)
                    index = 0;
            }

            cdMove = 0.2f;
        }
        txtDiff.fontStyle = FontStyle.Normal;
        labelDiff.fontStyle = FontStyle.Normal;
        txtSong.fontStyle = FontStyle.Normal;
        labelSong.fontStyle = FontStyle.Normal;

        if (index == 0)
		{
            txtDiff.fontStyle = FontStyle.Bold;
            labelDiff.fontStyle = FontStyle.Bold;

			if (Input.GetAxis("Horizontal") != 0 && cdMoveH <= 0)
			{
				if(Input.GetAxis("Horizontal") > 0)
				{
                    difficulty++;
					if(difficulty > 100){
						difficulty = 1;
					}

				} else {
                    difficulty--;
                    if (difficulty < 1)
                    {
                        difficulty = 100;
                    }

                }
                txtDiff.text = difficulty.ToString();
                cdMoveH = 0.1f;
                cdMove = 0.4f;
			}
		} else if(index == 1) {
            txtSong.fontStyle = FontStyle.Bold;
            labelSong.fontStyle = FontStyle.Bold;

            if (Input.GetAxis("Horizontal") != 0 && cdMove <= 0)
			{
				if(Input.GetAxis("Horizontal") > 0)
				{
					musicIndex--;
                    if (musicIndex < 0){
                        musicIndex = lstMusic.Count - 1;
                        
					}
                    txtSong.text = lstMusic[musicIndex].ToString();
				} else {
                    musicIndex++;
                    if (musicIndex > lstMusic.Count - 1){
                        musicIndex = 0;
					}
				}
                txtSong.text = lstMusic[musicIndex].ToString();
                cdMoveH = 0.1f;
                cdMove = 0.4f;
            }
			
		} else if(index == 2) {
            if (Input.GetButton("Submit"))
			{
                GameManager.difficulty = int.Parse(txtDiff.text);
                GameManager.song = txtSong.text;
				SceneManager.LoadScene("menuPrincipal");
			}
        }
        else
        {
            if(Input.GetButton("Submit"))
                SceneManager.LoadScene("menuPrincipal");
        }

        if(Input.GetButton("Cancel"))
            SceneManager.LoadScene("menuPrincipal");

        EventSystem.current.SetSelectedGameObject(GameObject.Find((string) lstOptions[index]));
        GameManager.menuMusicTime = audio.time;
    }
}
