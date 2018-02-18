using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon_state
{
    ready, charging, cooldown, disabled
}


public abstract class Weapon : Equipment {
    public float min_charge;
    public float max_charge;
    public int damage;
    public float range;
    public float attack_delay;  // An attack cannot be initiated for attack_delay of seconds after an attack is launched.
    public bool auto_release;   // If true, when full charge is met, weapon is automatically fired.
    public GameObject model;    // Must have a Sword_swing component

    // Hide in inspector
    // [HideInInspector]
    public Weapon_state state;
    [HideInInspector]
    public float cooldown_start_time;
    [HideInInspector]
    public float charge_start_time;

    public virtual void Start_charge(GameObject player) {
        charge_start_time = Time.time;
        state = Weapon_state.charging;
    }
    public virtual void Cancel_charge(GameObject player) {
        state = Weapon_state.ready;
    }
    public virtual void Attack(GameObject player) {
        cooldown_start_time = Time.time;
        state = Weapon_state.cooldown;
    }
}
