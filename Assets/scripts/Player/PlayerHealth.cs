using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    private int hp;
    public Text uihp;
    private bool inv;
    private float invTimer = 0;
    private float death = 0;
    public GameObject uihit;

    void Start () {
        uihp.color = new Color(0, 255, 0);
        hp = 100;
        uihp.text = "100";
        inv = false;

        GameManager.score = 0;
        GameManager.alive = true;
    }

    void Update ()
    {
        if (GameManager.alive)
        {
            if (hp > 80)
            {
                uihp.color = new Color(0, 1, 0);
            }
            else if (60 >= hp && hp > 30)
            {
                uihp.color = new Color(1, 1, 0);
            }
            else if (30 >= hp && hp > 0)
            {
                uihp.color = new Color(0.96f, 0.56f, 0.11f);
            }
            else if (hp == 0)
            {
                uihp.color = new Color(1, 0, 0);
                GameManager.alive = false;
            }

            if (invTimer > 0)
            {
                invTimer -= Time.deltaTime;
                Color color = uihit.GetComponent<Image>().color;
                color.a -= (float)0.6 / 60;
                uihit.GetComponent<Image>().color = color;
            }
            else
            {
                inv = false;
                Color color = uihit.GetComponent<Image>().color;
                color.a = 0;
                uihit.GetComponent<Image>().color = color;
            }
        }
        else 
        {
            Color color = uihit.GetComponent<Image>().color;
            color.a += (float)1 / 120;
            death += (float)1 / 120;
            uihit.GetComponent<Image>().color = color;

            if(death >= 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void hit(int damage)
    {
        if (!inv)
        {
            hp -= damage;

            if (hp < 0)
                hp = 0;

            uihp.text = hp.ToString();

            invTimer = 1;
            inv = true;
            Color color = uihit.GetComponent<Image>().color;
            color.a = 0.6f;
            uihit.GetComponent<Image>().color = color;
        }
    }
}
