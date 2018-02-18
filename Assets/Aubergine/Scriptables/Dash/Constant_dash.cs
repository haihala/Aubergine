using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Aubergine/Dash/Constant")]
public class Constant_dash : Dash {
	override public float power(float start_time) {
		// returns constant 1
		return 1f;
	}
}