using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	[HideInInspector]
	public int base_damage;

	Rigidbody2D rigidbody;
	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy(gameObject);

		Health health = collision.collider.gameObject.GetComponent<Health>();
		if (health) {
			// Collidee is something that can be damaged.
			health.Reduce(Damage());
		}
	}

	public virtual int Damage() {
		return base_damage;
	}
}
