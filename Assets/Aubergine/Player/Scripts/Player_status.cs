using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_status : MonoBehaviour {
	public IntVariable health;
	public IntVariable max_health;

	List<Status> statuses;

	public bool Has_status(Status status) {
		return statuses.Contains(status);
	}

	public void Inflict(Status status) {
		if (!Has_status(status) || status.stackable) {
			statuses.Add(status);
		}
	}

	public void Heal(int amount) {
		health.Value = Mathf.Min(max_health.Value, health.Value + amount);
	}
}
