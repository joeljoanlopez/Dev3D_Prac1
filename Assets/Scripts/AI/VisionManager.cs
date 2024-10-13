using System;
using Unity.VisualScripting;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
    [Header("Vision Parameters")]
    public float visionAngle = 90f;
    public float visionDistance = 100f;

    public bool isTargetSeen(GameObject target)
    {
        var targetDirection = target.transform.position - transform.position;
        var targetAngle = Vector3.Angle(transform.forward, targetDirection);
        var targetDistance = Vector3.Distance(transform.position, target.transform.position);

        if (targetDistance < visionDistance && targetAngle < visionAngle / 2f)
        {
            if (Physics.Raycast(transform.position, targetDirection, out var hit, visionDistance))
            {
                if (hit.collider.transform == target.transform)
                {
                    return true;
                }
            }
        }
        return false;
    }
}