using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 direction;
    private float currentSpeedX;
    private float currentSpeedY;
    private Vector2 currentVelocity;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetCurrentSpeedX(float currentSpeedX)
    {
        this.currentSpeedX = currentSpeedX;
    }

    public void SetCurrentSpeedY(float currentSpeedY)
    {
        this.currentSpeedY = currentSpeedY;
    }

    public void SetCurrentVelocity(float maxVelocityX, float maxVelocityY)
    {
        currentVelocity.Set(direction.x * Mathf.Clamp(currentSpeedX, 0, maxVelocityX),
            direction.y * Mathf.Clamp(currentSpeedY, -maxVelocityY, maxVelocityY));
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void ApplyMovement()
    {
        rb2d.velocity = currentVelocity;
    }
}
