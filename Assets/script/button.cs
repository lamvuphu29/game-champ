using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public bool enemies_check;
    public bool down;
    public LayerMask player;
    public Transform tf;
    public Transform pos1;
    public Transform pos2;
    public LayerMask enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D hit;
        if (enemies_check)
        {
            hit = Physics2D.OverlapArea(pos1.position, pos2.position, enemies);
            down = hit.isActiveAndEnabled;
        }
        else
        {
            hit = Physics2D.OverlapArea(pos1.position, pos2.position, player);
            down = hit.isActiveAndEnabled;
        }
    }
}
