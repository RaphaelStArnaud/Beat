using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour {

    public GameObject gun;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject weapon2;
    public Text uiammo;
    public Text uigrenade;
    public GameObject uigrenadeimage;
    public AudioSource fire1Sound;
    public AudioSource emptyFire1Sound;
    public Image reload, uiBullet;

    Weapon weaponScript;
    Color color;
    float coolDownFire;
    float coolDownReload;
    float coolDownReload2;
    private static int ammoReload;

	// Use this for initialization
	void Start () {
        color = new Color(0, 0, 0);
        coolDownFire = 0;
        coolDownReload = 0;
        coolDownReload2 = 0;

        weaponScript = GetComponent<Weapon>();

        uiammo.text = weaponScript.curAmmo + "/" + weaponScript.maxAmmo;
        uiammo.color = new Color(1,1,1);

        reload.enabled = false;
        uiBullet.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager.alive)
        {
            if (Input.GetKeyDown("joystick button 1"))
            {
                if (coolDownReload <= 0)
                {
                    coolDownReload = weaponScript.reloadSpeed;
                    ammoReload = 0;

                    for (int i = 0; i < weaponScript.maxAmmo; i++)
                    {
                        Timer timer = new Timer();
                        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        timer.Interval = (weaponScript.reloadSpeed / weaponScript.maxAmmo) * 1000 * i + 1;
                        timer.Enabled = true;
                    }
                }
            }
            if (Input.GetKey("joystick button 7") && coolDownFire <= 0 && coolDownReload <= 0)
            {
                fire();
            }
            else if (Input.GetKey("joystick button 6") && coolDownReload2 <= 0)
            {
                fire2();
            }

            if (coolDownFire > 0)
                coolDownFire -= Time.deltaTime;

            if (coolDownReload > 0)
            {
                reload.enabled = true;
                uiBullet.enabled = true;

                coolDownReload -= Time.deltaTime;
                uiammo.text = ammoReload.ToString();

                reload.fillAmount = (float)ammoReload / (float) weaponScript.maxAmmo;

                if (coolDownReload <= 0)
                    weaponScript.curAmmo = weaponScript.maxAmmo;
            } else
            {
                reload.enabled = false;
                uiBullet.enabled = false;
            }


            if (coolDownReload2 > 0)
            {
                uigrenade.text = "RELOADING";
                uigrenade.color = new Color(255, 0, 0);
                coolDownReload2 -= Time.deltaTime;

                Color color = uigrenadeimage.GetComponent<Image>().color;
                color.a = (10 - coolDownReload2) / 10;
                uigrenadeimage.GetComponent<Image>().color = color;
            }
            else
            {
                uigrenade.text = "READY";
                uigrenade.color = new Color(0, 255, 0);

                Color color = uigrenadeimage.GetComponent<Image>().color;
                color.a = 255;
                uigrenadeimage.GetComponent<Image>().color = color;
            }

            float ammo = 0;

            if (coolDownReload <= 0)
            {
                uiammo.text = weaponScript.curAmmo + "/" + weaponScript.maxAmmo;
                ammo = (float)weaponScript.curAmmo / weaponScript.maxAmmo;
            }
            else
            {
                uiammo.text = ammoReload + "/" + weaponScript.maxAmmo;
                ammo = (float)ammoReload / weaponScript.maxAmmo;
            }


            if (ammo > 0.8)
            {
                uiammo.color = new Color(0, 1, 0);
            }
            else if (0.6 >= ammo && ammo > 0.3)
            {
                uiammo.color = new Color(1, 1, 0);
            }
            else if (0.3 >= ammo && ammo > 0)
            {
                uiammo.color = new Color(0.96f, 0.56f, 0.11f);
            }
            else if (ammo == 0)
            {
                uiammo.color = new Color(1, 0, 0);
            }
        }
    }

    private void fire()
    {
        if (weaponScript.curAmmo > 0)
        {
            fire1Sound.Play();
            weaponScript.curAmmo--;

            GameObject spawnBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
            spawnBullet.GetComponent<Renderer>().material.color = color;
            spawnBullet.GetComponent<PlayerBullet>().color = color;

            coolDownFire = weaponScript.firerate;
        }
        else
        {
            if(!emptyFire1Sound.isPlaying)
                emptyFire1Sound.Play();
        }
            
    }

    private void fire2()
    {
        GameObject instance = Instantiate(weapon2, transform.position, transform.rotation) as GameObject;
        coolDownReload2 = instance.GetComponent<SecondaryWeapon>().getReloadSpeed();
        instance.GetComponent<SecondaryWeapon>().fire();
        
    }

    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        ((Timer)source).Stop();
        ammoReload++;
    }
}
