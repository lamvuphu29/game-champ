using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool dash_timer;
    public bool cool_down_timer;
    public int dash_timer_frame;
    public int cool_down_timer_frame;
    public int dash_timer_total_frame;
    public int cool_down_timer_total_frame;


    Vector2 vel;
    Vector2 vel1;
    public Collider2D collider;
    public Collider2D sheild_collider;
    public int sheild_hp;
    public float hp = 1000;
    public Camera cam;
    public Rigidbody2D rb;
    public Transform tf;
    public float speed;
    Vector2 movement;
    Vector2 look_vector;
    // Start is called before the first frame update
    void Start()
    {
        sheild_collider.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        look();
        dash();
        sheild();
    }
    void move()
    {
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            movement.x = Mathf.Sin(45 * Mathf.Deg2Rad) * Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.y = Mathf.Sin(45 * Mathf.Deg2Rad) * Input.GetAxisRaw("Vertical");
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    void look()
    {
        look_vector = cam.ScreenToWorldPoint(Input.mousePosition) - tf.position;
        rb.rotation = Mathf.Atan2(look_vector.y, look_vector.x) * Mathf.Rad2Deg;
    }
    void sheild()
    {
        if (Input.GetButton("Fire2")&&sheild_hp>0)
        {
            sheild_collider.enabled = true;
            sheild_hp--;
        }
        else
        {
            sheild_collider.enabled = false;
            if (sheild_hp<2000)
            {
                sheild_hp++;
            }
        }
        
    }
    void dash()
    {
        if (!cool_down_timer&&Input.GetButtonDown("Jump"))
        {
            cool_down_timer = true;
            dash_timer = true;
            collider.enabled=false;
            vel1.x = Mathf.Cos(rb.rotation * Mathf.Deg2Rad);
            vel1.y = Mathf.Sin(rb.rotation * Mathf.Deg2Rad);
        }
        if (cool_down_timer_total_frame <= cool_down_timer_frame)
        {
            cool_down_timer_frame = 0;
            cool_down_timer = !cool_down_timer;
        }
        if (cool_down_timer)
        {
            cool_down_timer_frame++;
        }
        if (dash_timer_total_frame <= dash_timer_frame)
        {
            dash_timer_frame = 0;
            dash_timer = !dash_timer;
            collider.enabled = true;

        }
        if (dash_timer)
        {
            dash_timer_frame++;
            rb.MovePosition(rb.position + vel1 * 80 * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (Input.GetButton("Fire1")&&Mathf.Abs(rb.rotation-Mathf.Atan2(collision.transform.position.y-tf.position.y, collision.transform.position.x-tf.position.x) *Mathf.Rad2Deg)<90)
            {
                vel.x = Mathf.Cos(rb.rotation * Mathf.Deg2Rad) * 5;
                vel.y = Mathf.Sin(rb.rotation * Mathf.Deg2Rad) * 5;
                collision.rigidbody.velocity = vel;
                Debug.Log(vel);
            }
            else
            {
                hp -= 50;
            }
        }
        if(collision.gameObject.layer == 9 && (!Input.GetButton("Fire2") || !(sheild_hp > 0)))
        {
            hp -= 200;
        }
    }
}
