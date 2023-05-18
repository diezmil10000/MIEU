using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z_Gizmo : MonoBehaviour
{

    public Transform detectionPoint;
    private const float detectionRadius = 2.0f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

}
