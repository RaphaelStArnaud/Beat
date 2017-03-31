using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SecondaryWeapon : MonoBehaviour {
    public float explosionTime { get; set; }
    public int aoe { get; set; }
    public float animationTime { get; set; }

    public abstract void fire();

    public abstract int getReloadSpeed();
}
