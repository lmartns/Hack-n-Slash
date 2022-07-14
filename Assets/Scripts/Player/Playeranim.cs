using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranim : MonoBehaviour
{
    public Player playervar;
    public Animator anim;

    void Start()
    {
        playervar = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        //Movement();
        attack();

    }

    void Movement()
    {
        if (playervar.isGround == false)
        {
            anim.SetBool("jump", true);
            anim.SetBool("move", false);
        }
        else if (playervar.isGround == true)
        {
            anim.SetBool("jump", false);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
    }

    void attack()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }


}
