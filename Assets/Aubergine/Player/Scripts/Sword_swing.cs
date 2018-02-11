using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_swing : MonoBehaviour {

	public Sword parent;

	float spawn_time;
	float rotation_amount;

	// Use this for initialization
	void Start () {
		spawn_time = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - spawn_time > parent.swing_time) {
			Destroy(gameObject);
		} else {
			float swing_phase = (Time.time - spawn_time)/parent.swing_time;  // 0-1
			rotation_amount = ((0.5f - Mathf.Pow(swing_phase-0.5f, 2f)) / (Mathf.PI / 8f)) * (Time.deltaTime / parent.swing_time) * parent.swing_side;

			transform.Rotate(0,0,rotation_amount * parent.swing_angle);
			transform.position = transform.rotation * Vector3.right * parent.range/2f + transform.parent.position;
		}
	}
}
