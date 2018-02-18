using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consumable_bar : MonoBehaviour {
	public List<Image> slots;
	public ConsumablesListVariable inventory;

	void Start() {
		foreach (Image img in slots) {
			img.enabled = false;
		}

	}

	void Update() {
		for (int i = 0; i < slots.Count; i++) {
			if (i < inventory.Value.Count) {
				slots[i].enabled = true;
				slots[i].sprite = inventory.Value[i].UI_image;
			} else {
				slots[i].enabled = false;
			}
		}
	}

}
