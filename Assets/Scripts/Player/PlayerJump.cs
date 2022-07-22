using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Player Controller")]
    private PlayerController playerController;

    [Header("Jump Variables")]
    public bool inFloor;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            playerController._rb.velocity = new Vector2(playerController._move.horizontalMove * playerController._move.speed, jumpForce);
            playerController.SwitchState(PlayerStatesMachine.JUMP);
            playerController._animator.SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inFloor = true;
            playerController.SwitchState(PlayerStatesMachine.MOVE);
            playerController._animator.SetBool("Jump", false);
        }
    }

    public void MoveJump()
    {
        playerController._move.horizontalMove = Input.GetAxisRaw("Horizontal");
        playerController._rb.velocity = new Vector2(playerController._move.horizontalMove * playerController._move.speed, playerController._rb.velocity.y);
        if (inFloor)
        {
            inFloor = false;
        }


        if (playerController._move.horizontalMove > 0)
        {
            playerController._sr.flipX = false;
        }

        else if (playerController._move.horizontalMove < 0)
        {
            playerController._sr.flipX = true;
        }

    }
}
