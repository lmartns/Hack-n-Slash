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
        Run();
        Jump();
    }
    void Run ()
    {
        if (playervar.playerRun == true)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    void Jump()
    {
        if(playervar.playerJump == true)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
    

}
