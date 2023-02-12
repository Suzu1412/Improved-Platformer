using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private IAgentInput input;
    private IMoveAgent movement;
    private JumpBehaviour jump;
    private Rigidbody2D rb2d;
    private CollissionSenses collissionSenses;
    private float speed = 5f;


    private void Awake()
    {
        input = GetComponentInParent<IAgentInput>();
        movement = GetComponent<IMoveAgent>();
        jump= GetComponent<JumpBehaviour>();
        rb2d= GetComponent<Rigidbody2D>();
        collissionSenses= GetComponentInChildren<CollissionSenses>();
    }

    private void Update()
    {
        ReadInput();

        movement.SetDirection(input.MovementVector);
        movement.SetCurrentSpeedX(speed);

        if (jump.IsJumping)
        {
            jump.ReduceJumpDurationBySeconds(Time.deltaTime);

            movement.SetCurrentSpeedY(15f);
        }
        else
        {
            movement.SetCurrentSpeedY(rb2d.velocity.y);
        }        
    }

    private void FixedUpdate()
    {
        movement.SetCurrentVelocity(5f, 30f);
        movement.ApplyMovement();
    }

    private void ReadInput()
    {
        if (input.JumpPressed)
        {
            if (!collissionSenses.IsGrounded) return;

            jump.ActivateJump(0.25f);
        }

        if (input.JumpReleased)
        {
            jump.SetJumpDuration(0f);
        }
    }
}
