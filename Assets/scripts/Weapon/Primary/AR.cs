using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : Weapon {

	// Use this for initialization
	void Start () {
        maxAmmo = 35;
        curAmmo = maxAmmo;
        firerate = 0.18f;
        reloadSpeed = 2;
    }
}
