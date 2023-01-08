using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolderMove : MonoBehaviour
{
    public float zRotation;
    public enum FlipStatus
    {
        X,
        Y,
        Z
    }
    
    [HideInInspector] public FlipStatus status;
    [SerializeField] private float turnSpeed;
    
    public bool flippedY;
    public bool flippedX;
    public bool flippedZ;
    
    // Start is called before the first frame update
    void Awake()
    {
        status = FlipStatus.Y;
        flippedY = false;
        flippedX = false;
        flippedZ = false;
        zRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case FlipStatus.Y:
            {
                switch (flippedY)
                {
                    case false:
                    {
                        //transform.rotation = Quaternion.Euler(childTransform.rotation.x,childTransform.rotation.y, Mathf.Lerp(transform.eulerAngles.z, 0, turnSpeed));
                        zRotation = 0;
                        break;
                    }
                    case true:
                    {
                        //transform.rotation = Quaternion.Euler(childTransform.rotation.x,childTransform.rotation.y, Mathf.Lerp(transform.eulerAngles.z, 180, turnSpeed));
                        zRotation = 180;
                        break;
                    }
                }
                break;
            }
            case FlipStatus.X:
            {
                switch (flippedX)
                {
                    case false:
                    {
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 270, turnSpeed));
                        break;
                    }
                    case true:
                    {
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 90, turnSpeed));
                        break;
                    }
                }
                break;
            }
            case FlipStatus.Z:
            {
                switch (flippedZ)
                {
                    case false:
                    {
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 90, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 0, turnSpeed));
                        //transform.rotation = Quaternion.Euler(Vector3.Slerp(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), new Vector3(90,0,0), turnSpeed));
                        break;
                    }
                    case true:
                    {
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, -90, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 0, turnSpeed));
                        //transform.rotation = Quaternion.Euler(Vector3.Slerp(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), new Vector3(270,0,0), turnSpeed)); 
                        break;
                    }
                }
                break;
            }
        }
        
    }
    
}
