using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour {
    int speed;
    public Color color { get; set; }

	// Use this for initialization
	void Start () {
        speed = 25;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            transform.root.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            Destroy(transform.root.gameObject);

            Text uiscore = (Text) GameObject.Find("ScoreValue").GetComponent<Text>();

            int score = int.Parse(uiscore.text);
            score += GameManager.difficulty;
            uiscore.text = score.ToString();
            GameManager.score = score;

            collision.gameObject.GetComponent<AI>().death();
        }
        else
        {
            transform.root.gameObject.SetActive(false);
            Destroy(transform.root.gameObject);
        }
    }
}
