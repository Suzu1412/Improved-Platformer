using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private Collider2D agentCollider;
    private CollissionSensesDataSO collissionData;
    private bool isGrounded;
    private Coroutine detectionCoroutine;
    private WaitForSeconds waitForSeconds = new(0.2f);

    public bool IsGrounded => isGrounded;

    private void Awake()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        detectionCoroutine = StartCoroutine(DetectionCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(detectionCoroutine);
    }

    internal void SetCollider(Collider2D agentCollider)
    {
        this.agentCollider = agentCollider;
    }

    internal void SetCollissionData(CollissionSensesDataSO data)
    {
        collissionData = data;

        waitForSeconds = new(collissionData.GroundDetectionDelay);
    }

    private IEnumerator DetectionCoroutine()
    {
        while (true)
        {
            if (collissionData == null)
            {
                yield return null;
            }

            yield return waitForSeconds;

            CheckIsGrounded();
        }
    }

    private void CheckIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(agentCollider.bounds.center, agentCollider.bounds.size, 0f, Vector2.down, collissionData.BoxCastYOffset, collissionData.GroundMask);

        isGrounded = raycastHit.collider != null;
    }

    #region Gizmos
    private void OnDrawGizmos()
    {
        if (agentCollider == null) return;

        Gizmos.color = collissionData.IsNotCollidingColor;

        if (isGrounded) Gizmos.color = collissionData.IsCollidingColor;

        DrawBottomRightRay(agentCollider);
        DrawBottomLeftRay(agentCollider);
        DrawBottomRay(agentCollider);
    }

    /// <summary>
    /// Draw Ray Gizmos on the right side of the collider in direction to the ground
    /// </summary>
    private void DrawBottomRightRay(Collider2D agentCollider)
    {
        Gizmos.DrawRay(agentCollider.bounds.center + new Vector3(agentCollider.bounds.extents.x, 0), Vector2.down * (agentCollider.bounds.extents.y + collissionData.BoxCastYOffset));
    }

    /// <summary>
    /// Draw Ray Gizmos on the left side of the collider in direction to the ground
    /// </summary>
    private void DrawBottomLeftRay(Collider2D agentCollider)
    {
        Gizmos.DrawRay(agentCollider.bounds.center - new Vector3(agentCollider.bounds.extents.x, 0), Vector2.down * (agentCollider.bounds.extents.y + collissionData.BoxCastYOffset));
    }

    /// <summary>
    /// Draw Ray gizmos that covers all of the ground area of the collider
    /// </summary>
    private void DrawBottomRay(Collider2D agentCollider)
    {
        Gizmos.DrawRay(agentCollider.bounds.center - new Vector3(agentCollider.bounds.extents.x, agentCollider.bounds.extents.y + collissionData.BoxCastYOffset), Vector2.right * (agentCollider.bounds.extents.x * 2));
    }
    #endregion
}
