using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Aubergine/Potion/Healing")]
public class Healing_potion : Potion {
	public int healAmount;
	public override void OnUse(Player_status ps) {
		ps.Heal(healAmount);
	}
}
