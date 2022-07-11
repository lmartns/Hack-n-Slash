using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranim : MonoBehaviour
{
    private Player player;
    public Animator anim;


    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimaJump();
        AnimaRun();

    }

    void AnimaJump()
    {
        if (player.pulopulo)
        {
            anim.SetInteger("transition", 2);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
    }

    void AnimaRun()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("transition", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("transition", 1);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
    }
}
