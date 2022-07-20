using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public float jumpForce;
    public bool inFloor = true;
    public bool playerRun;
    public bool playerJump;
    public bool playerDash;
    public bool playerSlide;
    public bool EnableSlide;
    public float TimeSlideee = 0.4f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        EnableSlide = true;
    }

    void Update()
    {
        Jump();
        Slide();
        _ = StartCoroutine("Test");
    }

    private void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (horizontalMove * speed, rb.velocity.y);

        if(horizontalMove > 0)
        {
            sr.flipX = false;
            playerRun = true;
        }

        else if (horizontalMove < 0)
        {
            sr.flipX = true;
            playerRun = true;
        }
        else
        {
            playerRun = false;
        }
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            playerJump = true;
            rb.AddForce(new Vector2(0, jumpForce));
            inFloor = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerJump = false;
            inFloor = true;
        }
    }

    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && EnableSlide == true)
        {
            playerSlide = true;
            EnableSlide = false;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSlide = false;
        }
    }
        IEnumerator Test()
        {
            yield return new WaitForSeconds (TimeSlideee);
            EnableSlide = true;
        } 
}
