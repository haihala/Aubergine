using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour {
	public SwordVariable sword;
	public GunVariable gun;


	void Start() {
		sword.Value.state = Weapon_state.ready;
		gun.Value.state = Weapon_state.ready;
	}

	void Update () {
		bool sword_down = Input.GetButtonDown("Sword");
		bool sword_up = Input.GetButtonUp("Sword");
		bool gun_down = Input.GetButtonDown("Gun");
		bool gun_up = Input.GetButtonUp("Gun");

		// Cancel when the other is pressed or if button is prematurely released
		// Launch attack if the button is held on for the required time.
		if (sword.Value.state == Weapon_state.charging) {
			if (gun_down) {
				sword.Value.Cancel_charge(gameObject);
			} else if (sword_up) {
				if (Time.time - sword.Value.charge_start_time > sword.Value.min_charge) {
					sword.Value.Attack(gameObject);
				} else {
					sword.Value.Cancel_charge(gameObject);
				}
			} else if (sword.Value.auto_release && Time.time - sword.Value.charge_start_time > sword.Value.max_charge) {
				sword.Value.Attack(gameObject);
			}
		} else if (gun.Value.state == Weapon_state.charging) {
			if (sword_down) {
				gun.Value.Cancel_charge(gameObject);
			} else if (gun_up) {
				if (Time.time - gun.Value.charge_start_time > gun.Value.min_charge) {
					gun.Value.Attack(gameObject);
				} else {
					gun.Value.Cancel_charge(gameObject);
				}
			} else if (gun.Value.auto_release && Time.time - gun.Value.charge_start_time > gun.Value.max_charge) {
				gun.Value.Attack(gameObject);
			}
		}
		// If not charging, start charging
		if (sword.Value.state == Weapon_state.ready) {
			if (sword_down) {
				sword.Value.Start_charge(gameObject);
				return;  // To prevent charging both.
			}
		}

		if (gun.Value.state == Weapon_state.ready) {
			if (gun_down) {
				if (gun.Value.ammo_current.Value >= gun.Value.ammo_consumption.Value) {
					gun.Value.Start_charge(gameObject);
				}
			}
		}

		// Remove cooldown if it has passed.
		if (sword.Value.state == Weapon_state.cooldown
			&& Time.time - sword.Value.cooldown_start_time > sword.Value.attack_delay) {
			sword.Value.state = Weapon_state.ready;

		}

		if (gun.Value.state == Weapon_state.cooldown
			&& Time.time - gun.Value.cooldown_start_time > gun.Value.attack_delay) {
			gun.Value.state = Weapon_state.ready;
		}
	}
}
