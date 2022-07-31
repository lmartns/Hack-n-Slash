using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    readonly EnemyFollow enemyFollow;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    public void Update()
    {
        Run();
    }

    public void Run()
    {
        if(enemyFollow.following == true)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
