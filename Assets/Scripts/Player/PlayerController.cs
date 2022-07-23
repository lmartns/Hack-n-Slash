using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatesMachine
{
    
    DASH,
    MOVE,
    JUMP,
    ATTACK,
    NULL
}

public class PlayerController : MonoBehaviour
{
    [Header("Rigidbody Variables")]
    public Rigidbody2D _rb;

    [Header("Animator variables")]
    public Animator _animator;

    //Player State Machine
    [SerializeField] private PlayerStatesMachine currentState;
    [SerializeField] private PlayerStatesMachine lastState;

    [Header("Sprites variables")]
    public SpriteRenderer _sr;

    //Scripts = chama os scripts de fora, acessa as funções e as variáveis, funções e variáveis precisam ser publicas para serem acessadas
    public PlayerMovement _move;
    public PlayerJump _jump;
    public PlayerAttack _attack;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _move = GetComponent<PlayerMovement>();
        SwitchState(PlayerStatesMachine.MOVE);
        _sr = GetComponent<SpriteRenderer>();
        _jump = GetComponent<PlayerJump>();
        _attack = GetComponent<PlayerAttack>();

    }

    // Update is called once per frame
    void Update()
    {
        StatePlayerMachine();
    }

    //Funções da Maquina de estado
    public PlayerStatesMachine GetCurrentState()
    {
        return currentState;
    }

    public void SwitchState(PlayerStatesMachine newState)
    {
        lastState = GetCurrentState();
        currentState = newState;
    }

    private void StatePlayerMachine()
    {
        switch (currentState)
        {
            case PlayerStatesMachine.DASH:
                {
                    
                }
                break;
            case PlayerStatesMachine.JUMP:
                {
                    _jump.MoveJump();
                }
                break;
            case PlayerStatesMachine.MOVE:
                {

                    _jump.Jump();
                    _attack.Attack();
                    _move.Movement();
                    _move.Dash();

                    if (Input.GetButtonDown("Fire1"))
                    {
                        SwitchState(PlayerStatesMachine.ATTACK);
                        _animator.SetBool("Attack", true);
                    }
                }
                break;
            case PlayerStatesMachine.ATTACK:
                {
                    _rb.velocity = Vector2.zero;
                }
                break;
      
        }
    }

    public void InputController()
    {

    }

    public void EndAnimation()
    {
        AnimationSetFalse();
        SwitchState(PlayerStatesMachine.MOVE);
    }

    public void AnimationSetFalse()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Jump", false);
        _animator.SetBool("Slide", false);
        _animator.SetBool("Attack", false);
    }
}