using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Aubergine/Equipment/Gun")]
public class Gun : Weapon {

    public IntVariable ammo_capacity;     // Max ammo that can be held.
    public IntVariable ammo_consumption;  // Ammo drained per shot.
    public IntVariable ammo_current;      // Current ammo.
    public Vector2 grip;
    public GameObject projectile;
    public float projectile_speed;

    GameObject instance;
    GameObject player;

    public override void Attack (GameObject player) {
        base.Attack(player);

        Vector3 direction = new Vector3(Input.mousePosition.x - Screen.width/2f, Input.mousePosition.y - Screen.height/2f, 0).normalized;
        float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);
        // Spawn bullet
        GameObject bullet = Instantiate(projectile, player.transform.position + direction/2f, Quaternion.Euler(0,0,angle));
        Projectile proj = bullet.GetComponent<Projectile>();
        proj.base_damage = damage;

        // Set trajectory
        bullet.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0,0,angle) * Vector3.right * projectile_speed;

        // Reduce ammo
        ammo_current.Value = Mathf.Max(ammo_current.Value - ammo_consumption.Value, 0);

        // Destroy gun
        Destroy(instance);
    }

    public override void Start_charge(GameObject player) {
        base.Start_charge(player);
        this.player = player;

        Vector3 direction = new Vector3(Input.mousePosition.x - Screen.width/2f, Input.mousePosition.y - Screen.height/2f, 0).normalized;
        float angle = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);

        Vector2 start_point = (Quaternion.Euler(0,0,angle) * grip) + player.transform.position;

        instance = Instantiate(model, start_point, Quaternion.Euler(0, 0, angle), player.transform);
    }

    public override void Cancel_charge(GameObject player) {
        base.Cancel_charge(player);

        Destroy(instance);
    }
}
