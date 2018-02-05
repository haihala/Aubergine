using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WASD_mover : MonoBehaviour {
	// Publics
	public FloatVariable speed;
	public Dash dash;

	// Privates
	Rigidbody2D rigidbody;

	// Indicates the phase of the dash, since velocity is not constant.
	Vector2 dash_direction;
	float dash_start;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		dash_start = 0;
	}

	// Update is called once per frame
	void Update () {
		// Walking
		Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		direction.Normalize();
		direction *= speed.Value * Time.deltaTime;

		rigidbody.AddForce(direction);


		// Dash
		if (Time.time - dash_start < dash.duration) {
			// Dash is ongoing, continue
			rigidbody.AddForce(dash_direction * dash.force * dash.power(dash_start));

		} else if (Input.GetButton("Dash")) {
			if (Time.time - dash_start > dash.cooldown) {
				// Cooldown passed
				start_dash();
			}
		}
	}

	void start_dash(){
		dash_direction = new Vector2(Input.mousePosition.x - Screen.width/2F, Input.mousePosition.y - Screen.height/2F);
		dash_direction.Normalize();

		dash_start = Time.time;
	}
}
