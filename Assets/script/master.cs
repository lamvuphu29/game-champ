using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public Transform health_bar;
    public Transform white_bar_1;
    public Transform sheild_bar;
    public Transform white_bar_2;
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UI();
    }
    void UI()
    {
        health_bar.localScale = new Vector3(player.hp / 200f, 0.5F, 0);
        white_bar_1.localScale = new Vector3(player.max_hp / 200f, 0.5F, 0);
        sheild_bar.localScale = new Vector3(player.sheild_hp / 40f, 0.5F, 0);
        white_bar_2.localScale = new Vector3(player.max_sheild_hp / 40f, 0.5F, 0);



        health_bar.position = new Vector3(player.hp / 2 / 200f - 8, 4.5f, 0);
        white_bar_1.position = new Vector3(player.max_hp / 2 / 200f - 8, 4.5f, 0);
        sheild_bar.position = new Vector3(player.sheild_hp / 2 / 40f - 8, 3.75F, 0);
        white_bar_2.position = new Vector3(player.max_sheild_hp / 2 / 40f - 8, 3.75F, 0);
    }
}
