using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    #region Coroutine Variables
    private Coroutine resetJumpCoroutine;
    private WaitForSeconds waitForSeconds = new(0.05f);
    #endregion

    public Vector2 MovementVector { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool JumpHold { get; private set; }
    public bool JumpReleased { get; private set; }

    #region Implement Interface
    public void CallOnMovementVector(Vector2 input)
    {
        MovementVector = input;
    }

    public void CallOnJumpPressed()
    {
        JumpPressed = true;
        JumpHold = true;
        JumpReleased = false;
        resetJumpCoroutine = StartCoroutine(ResetJumpCoroutine());
    }

    public void CallOnJumpReleased()
    {
        JumpPressed = false;
        JumpHold = false;
        JumpReleased = true;
    }
    #endregion


    public void CallOnMovement(InputAction.CallbackContext context)
    {
        CallOnMovementVector(context.ReadValue<Vector2>());
    }

    public void CallOnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                CallOnJumpPressed();
                break;

            case InputActionPhase.Performed:
                break;

            case InputActionPhase.Canceled:
                CallOnJumpReleased();
                break;
        }
    }


    #region Coroutines
    private IEnumerator ResetJumpCoroutine()
    {
        JumpPressed = true;
        yield return waitForSeconds;
        JumpPressed = false;
    }

    
    #endregion
}
