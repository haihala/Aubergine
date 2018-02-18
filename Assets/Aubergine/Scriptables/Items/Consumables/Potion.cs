using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Consumable {
    // Potions only affect the player using them.
    public virtual void OnUse(Player_status ps) {}
}
