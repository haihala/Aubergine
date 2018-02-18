using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class Dash : ScriptableObject {
	public float duration;
	public float force;
	public float cooldown;

	abstract public float power(float start_time);
}