using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionSenses : MonoBehaviour
{
    private Collider2D agentCollider;
    [SerializeField] private CollissionSensesDataSO collissionData;

    private GroundDetector groundDetector;

    public bool IsGrounded => groundDetector.IsGrounded;

    private void Awake()
    {
        if (collissionData == null) Debug.LogError("Agent Collission Data is Empty in: " + this.name);

        groundDetector = GetComponent<GroundDetector>();

        SetCollissionData();
    }

    private void SetCollissionData()
    {
        if (groundDetector != null) groundDetector.SetCollissionData(collissionData);
    }

}
