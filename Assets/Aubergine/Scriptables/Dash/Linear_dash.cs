using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Aubergine/Dash/Linear")]
public class Linear_Dash : Dash {
	override public float power(float start_time) {
		// returns constant 1
		return (Time.time - start_time) / duration;
	}
}