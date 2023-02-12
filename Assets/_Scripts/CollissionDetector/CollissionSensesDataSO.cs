using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Collission Senses Data", fileName = "CollissionData_")]
public class CollissionSensesDataSO : ScriptableObject
{
    [Header("Mask Parameters:")]
    [Space]
    [SerializeField] private LayerMask groundMask;

    [Header("Detection Delay Parameters:")]
    [Space]
    [SerializeField][Range(0.05f, 0.3f)] private float groundDetectionDelay = 0.05f;


    [Header("Gizmo Parameters:")]

    [Range(-2f, 2f)]
    [SerializeField] private float boxCastXOffset = 0f;

    [Range(-2f, 2f)]
    [SerializeField] private float boxCastYOffset = 0.1f;


    [SerializeField] private Color isCollidingColor = Color.green;
    [SerializeField] private Color isNotCollidingColor = Color.red;


    #region Public Fields
    public LayerMask GroundMask => groundMask;

    public float GroundDetectionDelay => groundDetectionDelay;

    public float BoxCastXOffset => boxCastXOffset;
    public float BoxCastYOffset => boxCastYOffset;

    public Color IsCollidingColor => isCollidingColor;
    public Color IsNotCollidingColor => isNotCollidingColor;
    #endregion
}
