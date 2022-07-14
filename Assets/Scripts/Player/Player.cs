using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer sr;
    public float move;
    public Vector3 facingRight;
    public Vector3 facingLeft;
    public float jumpForce = 10f;
    public bool isGround;
    public float speed = 4f;

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
        Onjump();
    }

    void FixedUpdate()
    {
        movement();
        Movespeed();
    }

    void movement()
    {
        move = Input.GetAxis("Horizontal");
        
        if(move < 0) 
        {
            sr.flipX = true;
        }
        else if (move > 0)
        {
            sr.flipX = false;
        }
    }
    void Movespeed()
    {
        rb.velocity = new Vector2 (move * speed, rb.velocity.y);
    }
    public void Onjump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rb.AddForce(transform.up * jumpForce);
            isGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }
}
