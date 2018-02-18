using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class Variable<T> : ScriptableObject {
    public T Value;
    public string Comment;
}


[CreateAssetMenu(menuName = "Aubergine/Variable/Float")]
public class FloatVariable : Variable<float> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/String")]
public class StringVariable : Variable<string> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/Int")]
public class IntVariable : Variable<int> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/Bool")]
public class BoolVariable : Variable<bool> { }


[CreateAssetMenu(menuName = "Aubergine/Variable/Vector3")]
public class Vector3Variable : Variable<Vector3> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/Vector2")]
public class Vector2Variable : Variable<Vector2> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/ConsumablesList")]
public class ConsumablesListVariable : Variable<List<Consumable>> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/Sword_reference")]
public class SwordVariable : Variable<Sword> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/Gun_reference")]
public class GunVariable : Variable<Gun> { }
[CreateAssetMenu(menuName = "Aubergine/Variable/Armor_reference")]
public class ArmorVariable : Variable<Armor> { }
