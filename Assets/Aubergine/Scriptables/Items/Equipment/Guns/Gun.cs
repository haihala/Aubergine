using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Aubergine/Equipment/Gun")]
public class Gun : Weapon {
    public float ammo_consumption;  // Ammo drained per shot.
    public float ammo_capacity;     // Max ammo that can be held.
    public float ammo_current;      // Current ammo.
    public GameObject projectile;
}
