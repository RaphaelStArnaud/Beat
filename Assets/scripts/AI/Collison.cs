using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour {
    private int damage = 10;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().hit(damage);
        }
    }
}
