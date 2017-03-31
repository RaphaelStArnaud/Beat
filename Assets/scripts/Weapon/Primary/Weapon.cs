using UnityEngine;

public class Weapon: MonoBehaviour { 
    public int maxAmmo { get; set; }
    public int curAmmo { get; set; }
    public float firerate { get; set; } //second
    public float reloadSpeed { get; set; } //second
}
