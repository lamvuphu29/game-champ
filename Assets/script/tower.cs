using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    Vector2 movement;
    Vector2 vel;
    public player player;
    public Transform tf;
    public int speed;
    public float angle;
    GameObject bullet;
    Vector3 gun;
    public GameObject bullet_prefab;
    bullet_code bullet_rb;
    public int cooldown;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        shoot();
    }
    void shoot()
    {
        angle = Mathf.Atan2(player.tf.position.y - tf.position.y, player.tf.position.x - tf.position.x) * Mathf.Rad2Deg;
        cooldown--;
        if (cooldown <= 0)
        {
            cooldown += 100;
            gun.x = tf.position.x + Mathf.Cos(angle * Mathf.Deg2Rad);
            gun.y = tf.position.y + Mathf.Sin(angle * Mathf.Deg2Rad);
            bullet = Instantiate(bullet_prefab, gun, Quaternion.identity);
            vel.x = Mathf.Cos(angle * Mathf.Deg2Rad);
            vel.y = Mathf.Sin(angle * Mathf.Deg2Rad);
            bullet_rb = bullet.GetComponent<bullet_code>();
            Debug.Log(vel);
            bullet_rb.vel = vel * 10;
        }
    }
}
