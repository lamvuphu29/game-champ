using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    Vector2 movement;
    Vector2 vel;
    public player player;
    public Rigidbody2D rb;
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
        move();
        shoot();
    }
    void move()
    {
        if (Mathf.Sqrt(Mathf.Pow(player.tf.position.x-tf.position.x,2)+Mathf.Pow(player.tf.position.y - tf.position.y,2))>3)
        {

            angle = Mathf.Atan2(player.tf.position.y - tf.position.y, player.tf.position.x - tf.position.x) * Mathf.Rad2Deg;
            movement.x = Mathf.Cos(angle * Mathf.Deg2Rad);
            movement.y = Mathf.Sin(angle * Mathf.Deg2Rad);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {

            angle = Mathf.Atan2(player.tf.position.y - tf.position.y, player.tf.position.x - tf.position.x) * Mathf.Rad2Deg;
            movement.x = Mathf.Cos(angle * Mathf.Deg2Rad);
            movement.y = Mathf.Sin(angle * Mathf.Deg2Rad);
            rb.MovePosition(rb.position - movement * speed * Time.fixedDeltaTime);
        }
    }
    void shoot()
    {
        angle = Mathf.Atan2(player.tf.position.y - tf.position.y, player.tf.position.x - tf.position.x) * Mathf.Rad2Deg;
        cooldown--;
        if (cooldown<=0)
        {
            cooldown += 100;
            gun.x = tf.position.x + Mathf.Cos(angle * Mathf.Deg2Rad);
            gun.y = tf.position.y + Mathf.Sin(angle * Mathf.Deg2Rad);
            bullet = Instantiate(bullet_prefab, gun, Quaternion.identity);
            vel.x = Mathf.Cos(angle * Mathf.Deg2Rad);
            vel.y = Mathf.Sin(angle * Mathf.Deg2Rad);
            bullet_rb = bullet.GetComponent<bullet_code>();
            Debug.Log(vel);
            bullet_rb.vel = vel*10;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
    
}
