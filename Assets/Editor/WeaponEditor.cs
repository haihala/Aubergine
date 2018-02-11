using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Weapon), true)]
public class WeaponEditor : Editor{

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		Weapon weapon = (Weapon) target;

		if (GUILayout.Button("Attack")) {
			weapon.Attack(GameObject.Find("Player"));
		}
	}
}
