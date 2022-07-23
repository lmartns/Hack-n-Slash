using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Controller")]
    private PlayerController playerController;

    public float speed;
    public float speedBase;
    public float horizontalMove;
    public float dash;
    public float timeDash;
    public bool isDash;
    public float dashCoolDown;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        isDash = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Movement()
    {
        if (playerController.GetCurrentState() != PlayerStatesMachine.MOVE)
        {
            return;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            playerController._rb.velocity = new Vector2(horizontalMove * speed, playerController._rb.velocity.y);
            if (horizontalMove == 0)
            {
                playerController._animator.SetBool("Run", false);
            }
            else
            {
                playerController._animator.SetBool("Run", true);
            }

            if (horizontalMove > 0)
            {
                playerController._sr.flipX = false;
            }

            else if (horizontalMove < 0)
            {
                playerController._sr.flipX = true;
            }
        }

    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isDash)
        {
            StartCoroutine("DashCoolDown");
            playerController.SwitchState(PlayerStatesMachine.DASH);
            playerController._animator.SetBool("Slide", true);
            StartCoroutine("DashTime");
            playerController._rb.velocity = new Vector2(horizontalMove * speed, playerController._rb.velocity.y);
        }
    }

    IEnumerator DashTime()
    {
        speed = dash;
        yield return new WaitForSeconds(timeDash);
        playerController._animator.SetBool("Slide", false);
        speed = speedBase;
        playerController.SwitchState(PlayerStatesMachine.MOVE);
    }

    IEnumerator DashCoolDown()
    {
        isDash = false;
        yield return new WaitForSeconds(dashCoolDown);
        isDash = true; 
    }

}