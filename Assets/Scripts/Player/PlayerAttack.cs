using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Player Controller")]
    private PlayerController playerController;

    //[Header ("Attack Variables")]

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerController.SwitchState(PlayerStatesMachine.ATTACK);
            playerController._animator.SetBool("Attack", true);
        }
        

    }
}
