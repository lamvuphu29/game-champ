using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_code : MonoBehaviour
{
    public Vector2 vel;
    public Rigidbody2D rb;
    public int pierce = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pierce <= 0)
        {
            Destroy(gameObject);
        }
        rb.velocity += vel;
        vel *= 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        pierce--;
    }
}
