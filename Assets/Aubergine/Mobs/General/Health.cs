using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	// Class represents the health of an NPC
	// Mostly used for triggers.

	public IntVariable amount;

	public delegate void on_heal(int amount);
	public delegate void on_hurt(int amount);
	public delegate void on_change(int amount);

	public on_heal heal_callback;
	public on_hurt hurt_callback;
	public on_change change_callback;

	public void Start() {
		hurt_callback += Check_die;
	}

	public void Gain(int amount) {
		Change(Mathf.Abs(amount));
		heal_callback(amount);
	}

	public void Reduce(int amount) {
		Change(-Mathf.Abs(amount));
		hurt_callback(amount);
	}

	void Check_die(int damage) {
		if (amount.Value - damage <= 0) {
			// As it stands, vanishing is fine.
			Destroy(gameObject);
		}
	}

	void Change (int amount) {
		this.amount.Value += amount;
		change_callback(amount);
	}
}
