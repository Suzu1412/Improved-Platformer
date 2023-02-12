using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentInput
{
    Vector2 MovementVector { get; }
    bool JumpPressed { get; }
    bool JumpHold { get; }
    bool JumpReleased { get;  }

    void CallOnMovementVector(Vector2 input);

    void CallOnJumpPressed();

    void CallOnJumpReleased();
}
