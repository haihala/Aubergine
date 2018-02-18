using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Aubergine/Dash/Reverse_Linear")]
public class Reverse_Linear_Dash : Dash {
	override public float power(float start_time) {
		// returns constant 1
		return (duration + start_time - Time.time) / duration;
	}
}