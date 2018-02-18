using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_swing : MonoBehaviour {

	public Sword parent;
	[HideInInspector]
	public bool go;
	[HideInInspector]
	public float start_time;
	float rotation_amount;

	// Use this for initialization
	void Start () {
		go = false;
	}

	// Update is called once per frame
	void Update () {
		if (go) {
			if (Time.time - start_time > parent.swing_time) {
				Destroy(gameObject);
			} else {
				float swing_phase = (Time.time - start_time)/parent.swing_time;  // 0-1
				rotation_amount = ((0.5f - Mathf.Pow(swing_phase-0.5f, 2f)) / (Mathf.PI / 8f)) * (Time.deltaTime / parent.swing_time) * parent.swing_side;

				transform.Rotate(0,0,rotation_amount * parent.swing_angle);
				transform.position = transform.rotation * Vector3.right * parent.range/2f + transform.parent.position;
			}
		}
	}
}
