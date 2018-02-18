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
    GameObject instance;


    public override void Attack (GameObject player) {
        base.Attack(player);

        Sword_swing comp = instance.GetComponent<Sword_swing>();
        comp.go = true;
        comp.start_time = Time.time;
    }

    public override void Start_charge(GameObject player) {
        base.Start_charge(player);

        swing_side = Random.Range(0,2) * 2 - 1;
        Vector3 direction = new Vector3(Input.mousePosition.x - Screen.width/2f, Input.mousePosition.y - Screen.height/2f, 0).normalized;
        float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);

        angle += swing_angle/2f;
        if (swing_side == 1) {
            angle -= swing_angle;
        }


        Vector2 start_point = range/2f * (Quaternion.Euler(0,0,angle) * Vector3.right) + player.transform.position;

        instance = Instantiate(model, start_point, Quaternion.Euler(0, 0, angle), player.transform);
    }

    public override void Cancel_charge(GameObject player) {
        base.Cancel_charge(player);

        Destroy(instance);
    }

}
