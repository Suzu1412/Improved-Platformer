using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAgent
{
    void SetDirection(Vector2 direction);

    void SetCurrentSpeedX(float currentSpeedX);

    void SetCurrentSpeedY(float currentSpeedY);

    void SetCurrentVelocity(float maxVelocityX, float maxVelocityY);

    void ApplyMovement();
}
