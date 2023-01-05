using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turret : MonoBehaviour
{
    [SerializeField] private TurretLogic logic;
    [SerializeField] private Mount[] mounts;
    [SerializeField] private Transform target;

    void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        if (!target) return;

        var dashLineSize = 2f;
        foreach (var mountPoint in mounts)
        {
            var hardpoint = mountPoint.transform;
            var from = Quaternion.AngleAxis(-mountPoint.limit / 2, hardpoint.up) * hardpoint.forward;
            var projection = Vector3.ProjectOnPlane(target.position - hardpoint.position, hardpoint.up);

            // projection line
            Handles.color = Color.white;
            Handles.DrawDottedLine(target.position, hardpoint.position + projection, dashLineSize);

            // do not draw target indicator when out of angle
            if (Vector3.Angle(hardpoint.forward, projection) > mountPoint.limit / 2) return;

            // target line
            Handles.color = Color.red;
            Handles.DrawLine(hardpoint.position, hardpoint.position + projection);

            // range line
            Handles.color = Color.green;
            Handles.DrawWireArc(hardpoint.position, hardpoint.up, from, mountPoint.limit, projection.magnitude);
            Handles.DrawSolidDisc(hardpoint.position + projection, hardpoint.up, .5f);
#endif
        }
    }

    void Update()
    {
        
        if (!target) return;
            
        bool aimed = true;
        foreach (var mountPoint in mounts)
        {
            if (!mountPoint.Aim(target.position))
            {
                aimed = false;
            }
        }

        if (aimed)
            logic.Shoot();
    }
    
}