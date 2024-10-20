using System;
using Unity.VisualScripting;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
    [Header("Vision Parameters")]
    public float visionAngle = 90f;

    public bool isTargetSeen(GameObject target, float visionDistance)
    {
        var targetDirection = target.transform.position - transform.position;
        var targetAngle = Vector3.Angle(transform.forward, targetDirection);
        var targetDistance = Vector3.Distance(transform.position, target.transform.position);

        if (targetDistance <= visionDistance && targetAngle < visionAngle / 2f)
        {
            if (Physics.Raycast(transform.position, targetDirection, out var hit, visionDistance))
            {
                Debug.Log($"Raycast hit: {hit.transform.parent}");
                Debug.Log($"Raycast target: {target.transform}");
                if (hit.transform.parent == target.transform)
                {
                    return true;
                }
            }
        }
        return false;
    }
}