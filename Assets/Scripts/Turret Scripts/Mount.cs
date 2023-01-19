using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Mount : MonoBehaviour
{
    [Range(0, 360f)]
    public float limit = 90f;
    
    [Range(0, 360f)]
    [SerializeField] private float tolerance = 13131231123f;
    [SerializeField] private float turnSpeed = 90f;
    
    private Transform tower;
 
    void Awake()
    {
        tower = transform.GetChild(0);
    }

    private void OnDrawGizmos()
    {
        var range = 20f;
        var point = transform;
        var from = Quaternion.AngleAxis(-limit / 2, point.up) * point.forward;

        //Handles.color = new Color(0, 0, 0, .2f);
        //Handles.DrawSolidArc(point.position, point.up, from, limit, range);
    }
    
    public bool Aim(Vector3 target)
    {
        return Aim(target, out _);
    }
    
    public bool Aim(Vector3 targetPoint, out bool reachAngleLimit)
    {
        reachAngleLimit = default;
        var hardpoint = transform;
        var los = targetPoint - hardpoint.position;
        var halfAngle = limit / 2;
        var losOnPlane = Vector3.ProjectOnPlane(los, hardpoint.up);
        var deltaAngle = Vector3.SignedAngle(hardpoint.forward, losOnPlane, hardpoint.up);

        if (Mathf.Abs(deltaAngle) > halfAngle)
        {
            reachAngleLimit = true;
            losOnPlane = hardpoint.rotation * Quaternion.Euler(0, Mathf.Clamp(deltaAngle, -halfAngle, halfAngle), 0) * Vector3.forward;
        }

        var targetRotation = Quaternion.LookRotation(losOnPlane, hardpoint.up);
        var aimed = !reachAngleLimit && Quaternion.Angle(tower.rotation, targetRotation) < tolerance;
        tower.rotation = Quaternion.RotateTowards(tower.rotation, targetRotation, turnSpeed * Time.deltaTime);

        return aimed;
    }
}
