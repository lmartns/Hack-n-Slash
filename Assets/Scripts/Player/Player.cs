using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    
    public float speed = 4f;
    public Animator animator;

    private Vector3 facingRight;
    private Vector3 facingLeft;
    public float jumpForce = 10f;

    public bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rb.AddForce(transform.up * jumpForce);
            isGround = false;
        }
        animation();
    }

    void FixedUpdate()
    {
        movement();
    }

    #region Movement
    void movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, 0);
            animator.SetBool("Run", true);
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, 0);
            animator.SetBool("Run", true);
            sr.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("Run", false);
        }
    }
    #endregion 

    void jump()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }

    void animation()
    {
        if(isGround==false)
        {
            animator.SetBool("Jump", true);
        }
         if(isGround==true)
        {
            animator.SetBool("Jump", false);
        }
        

    }
}
