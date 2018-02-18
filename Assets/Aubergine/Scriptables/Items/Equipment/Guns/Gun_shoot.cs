using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_shoot : MonoBehaviour {

	public Gun parent;

	void Update () {
		// Keep facing cursor
        Vector3 direction = new Vector3(Input.mousePosition.x - Screen.width/2f, Input.mousePosition.y - Screen.height/2f, 0).normalized;
        float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);
		transform.rotation = Quaternion.Euler(0,0,angle);

		// Position correctly
		transform.position = Quaternion.Euler(0,0,angle) * (parent.grip) + transform.parent.position;
	}
}
