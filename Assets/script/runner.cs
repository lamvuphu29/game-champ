using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner : MonoBehaviour
{
    Vector2 movement;
    public player player;
    public Rigidbody2D rb;
    public Transform tf;
    public int speed;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }
    void move()
    {
        angle = Mathf.Atan2(player.tf.position.y - tf.position.y, player.tf.position.x - tf.position.x) * Mathf.Rad2Deg;
        movement.x = Mathf.Cos(angle * Mathf.Deg2Rad);
        movement.y = Mathf.Sin(angle * Mathf.Deg2Rad);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
}
