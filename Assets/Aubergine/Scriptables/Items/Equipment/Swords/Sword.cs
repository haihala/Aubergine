using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Aubergine/Equipment/Sword")]
public class Sword : Weapon {
    public float swing_time;
    public float swing_angle;
    [Range(1,100)]
    public float weight;

    public int swing_side;

    [HideInInspector]
    public Vector2 start_point;


    public override void Attack (GameObject player) {
        base.Attack(player);
        // Create hurtbox and visuals
        Vector3 direction = new Vector3(Input.mousePosition.x - Screen.width/2f, Input.mousePosition.y - Screen.height/2f, 0).normalized;
        float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);

        angle += swing_angle/2f;
        if (swing_side == 1) {
            angle -= swing_angle;
        }

        start_point = range/2f * (Quaternion.Euler(0,0,angle) * Vector3.right) + player.transform.position;

        GameObject instance = Instantiate(model, start_point, Quaternion.Euler(0, 0, angle), player.transform);
    }

    public override void Start_charge(GameObject player) {
        base.Start_charge(player);

        // Random swing side.
        swing_side = Random.Range(0,2) * 2 - 1;

    }
}
