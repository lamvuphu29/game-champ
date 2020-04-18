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
    Rigidbody2D bullet_rb;
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
        if (Mathf.Abs(player.tf.position.x - tf.position.x) > 5 && Mathf.Abs(player.tf.position.y - tf.position.y) > 5)
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
        bullet = Instantiate(bullet_prefab,gun,Quaternion.identity);
        vel.x = Mathf.Cos(angle * Mathf.Deg2Rad);
        vel.y = Mathf.Sin(angle * Mathf.Deg2Rad);
        bullet_rb = bullet.GetComponent<Rigidbody2D>();
        bullet_rb.velocity = vel;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
    
}
