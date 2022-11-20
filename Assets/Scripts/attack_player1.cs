using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class attack_player1 : MonoBehaviour
{
    public  Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("Attack_Left", true);
        }
        else
        {
            anim.SetBool("Attack_Left", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Attack_Right", true);
        }
        else
        {
            anim.SetBool("Attack_Right", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Kick", true);
        }
        else
        {
            anim.SetBool("Kick", false);
        }
    }
}
