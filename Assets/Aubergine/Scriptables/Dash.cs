using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Dash : ScriptableObject {
	public float duration;
	public float force;
	public float cooldown;

	abstract public float power(float start_time);
}


[CreateAssetMenu(menuName = "Aubergine/Dash/Basic")]
public class Basic_Dash : Dash {
	override public float power(float start_time) {
		// returns constant 1
		return 1f;
	}
}

[CreateAssetMenu(menuName = "Aubergine/Dash/Linear")]
public class Linear_Dash : Dash {
	override public float power(float start_time) {
		// returns constant 1
		return (Time.time - start_time) / duration;
	}
}

[CreateAssetMenu(menuName = "Aubergine/Dash/Reverse_Linear")]
public class Reverse_Linear_Dash : Dash {
	override public float power(float start_time) {
		// returns constant 1
		return (duration + start_time - Time.time) / duration;
	}
}