using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour {
	public Sword sword;
	public Gun gun;


	void Start() {
		sword.state = Weapon_state.ready;
		gun.state = Weapon_state.ready;
	}

	void Update () {
		bool sword_down = Input.GetButtonDown("Sword");
		bool sword_up = Input.GetButtonUp("Sword");
		bool gun_down = Input.GetButtonDown("Gun");
		bool gun_up = Input.GetButtonUp("Gun");

		// Cancel when the other is pressed or if button is prematurely released
		// Launch attack if the button is held on for the required time.
		if (sword.state == Weapon_state.charging) {
			if (gun_down) {
				sword.Cancel_charge(gameObject);
			} else if (sword_up) {
				if (Time.time - sword.charge_start_time > sword.min_charge) {
					sword.Attack(gameObject);
				} else {
					sword.Cancel_charge(gameObject);
				}
			} else if (sword.auto_release && Time.time - sword.charge_start_time > sword.max_charge) {
				sword.Attack(gameObject);
			}
		} else if (gun.state == Weapon_state.charging) {
			if (sword_down) {
				gun.Cancel_charge(gameObject);
			} else if (gun_up) {
				if (Time.time - gun.charge_start_time > gun.min_charge) {
					gun.Attack(gameObject);
				} else {
					gun.Cancel_charge(gameObject);
				}
			} else if (gun.auto_release && Time.time - gun.charge_start_time > gun.max_charge) {
				gun.Attack(gameObject);
			}

		// If not charging, start charging
		} else if (sword.state == Weapon_state.ready) {
			if (sword_down) {
				sword.Start_charge(gameObject);
			}
		} else if (gun.state == Weapon_state.ready) {
			if (gun_down) {
				gun.Start_charge(gameObject);
			}
		}

		// Remove cooldown if it has passed.
		if (sword.state == Weapon_state.cooldown
			&& Time.time - sword.cooldown_start_time > sword.attack_delay) {
			sword.state = Weapon_state.ready;

		} else if (gun.state == Weapon_state.cooldown
			&& Time.time - gun.cooldown_start_time > gun.attack_delay) {
			gun.state = Weapon_state.ready;
		}
	}
}
