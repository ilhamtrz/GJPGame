using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_player2 : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("Kick_Right", true);
        }
        else
        {
            anim.SetBool("Kick_Right", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("Kick_Left", true);
        }
        else
        {
            anim.SetBool("Kick_Left", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("Puch", true);
        }
        else
        {
            anim.SetBool("Puch", false);
        }



    }
}
