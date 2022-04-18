using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine_Jump : PlayerStateMachine
{
    public float deltaMove = 0.01f;
    private CharacterController controller;
    private PlayerMove playerMove;

    private float detectGroundTimeLimit = 1f;
    private float detectGroundtimer;
    private float jumpUpTime;
    private float jumpUpTimer;

    public override void Awake()
    {
        base.Awake();
        controller = GetComponent<CharacterController>();
        playerMove = GetComponent<PlayerMove>();
    }

    public override bool IsExecuteOK()
    {
        if ((manager.playerstate == PlayerState.Idle ||
             manager.playerstate == PlayerState.Move) &&
             controller.isGrounded)
            return true;
        return false;
    }

    public override PlayerState Workflow()
    {
        PlayerState nextState = playerState;

        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                playerAnimator.SetTrigger("doJump");
                detectGroundtimer = detectGroundTimeLimit;
                jumpUpTimer = jumpUpTime;
                state++;
                break;
            case State.Casting:
                if (controller.isGrounded == false)
                    state++;
                else if (detectGroundtimer < 0)
                    state = State.Finish;
                else 
                    detectGroundtimer -= Time.deltaTime;
                playerMove.SetMove(deltaMove);
                break;
            case State.OnAction:
                if (controller.velocity.y < 0)
                    playerAnimator.SetTrigger("doFall");
                if (controller.isGrounded)
                    state++;
                if (jumpUpTimer > 0)
                {
                    playerMove.SetMove(deltaMove);
                    jumpUpTimer -= Time.deltaTime;
                }
                    break;
            case State.Finish:
                nextState = PlayerState.Idle;
                state = State.Idle;
                break;
            default:
                break;
        }

        return nextState;
    }
}
