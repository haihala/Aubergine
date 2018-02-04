using UnityEngine;

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