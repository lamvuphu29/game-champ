using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour
{
    public player player;
    public bool health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (health)
        {
            player.hp = player.max_hp;
        }
        Destroy(gameObject);
    }
}
