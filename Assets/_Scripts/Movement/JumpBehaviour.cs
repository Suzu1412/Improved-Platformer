using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    private HorizontalMovement movement;
    [Header("Jump Variables")]
    [SerializeField] private int amountOfJumps;
    [SerializeField] private bool isJumping;
    [SerializeField] private float jumpSpeed;
    private float jumpDuration;

    [Header("Coyote Variables")]
    [SerializeField] private bool canEnterCoyoteTime;
    private bool isInCoyoteTime;
    private float coyoteTimeDuration;

    public bool IsJumping => isJumping;

    private void Awake()
    {
        movement = GetComponent<HorizontalMovement>();
    }

    public void ActivateJump(float jumpDuration)
    {
        canEnterCoyoteTime = false;
        isJumping = true;
        SetJumpDuration(jumpDuration);
        ConsumeJump();
    }

    public void ResetJump(int amountOfJumps)
    {
        isJumping = false;
        canEnterCoyoteTime = true;
        this.amountOfJumps = amountOfJumps;
    }

    public void ConsumeJump()
    {
        if (amountOfJumps > 0)
        {
            amountOfJumps--;
        }
    }

    public void SetJumpDuration(float jumpDuration)
    {
        this.jumpDuration = jumpDuration;
    }

    public void ReduceJumpDurationBySeconds(float seconds)
    {
        jumpDuration -= seconds;

        if (jumpDuration <= 0f)
        {
            isJumping = false;
        }
    }
}
