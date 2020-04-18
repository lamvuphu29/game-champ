using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_code : MonoBehaviour
{
    public Vector2 vel;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
