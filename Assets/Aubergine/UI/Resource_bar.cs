using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_bar : MonoBehaviour {
    public GameObject prefab;
    public IntVariable current;
    public IntVariable max;

    public void Update() {
        if (transform.childCount < current.Value) {
            Instantiate(prefab, transform);
        } else if (transform.childCount > current.Value) {
            Destroy(transform.GetChild(transform.childCount-1).gameObject);
        }
    }
}
