using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranim : MonoBehaviour
{
    public Player PlayerVar;
    public Animator anim;
    public bool AttackingBool;

    void Start()
    {
        PlayerVar = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Jump();
        Attack();
        Slide();
    }
    void Run()
    {
        if (PlayerVar.playerRun == true)
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
        if (PlayerVar.playerJump == true)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && PlayerVar.inFloor == true)
        {
            anim.SetBool("Attack", true);
            PlayerVar.speed = 0;
            
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Attack", false);
            PlayerVar.speed = 10;
        }
    }
    void Slide()
    {
        if (PlayerVar.playerSlide == true)
        {
            anim.SetBool("Slide", true);
        }
        else
        {
            anim.SetBool("Slide", false);
        }
    }
}
