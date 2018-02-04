using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_mover : MonoBehaviour {
	// Publics
	public FloatVariable speed;

	// Privates
	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		Vector2 Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Direction.Normalize();
		Direction *= speed.Value * Time.deltaTime;

		rigidbody.AddForce(Direction);

	}
}
