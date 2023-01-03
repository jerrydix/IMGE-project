using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolderMove : MonoBehaviour
{
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
                        /*float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                        
                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        
                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);*/
                        
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 0, turnSpeed));
                        //orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
                        break;
                    }
                    case true:
                    {
                       /* float x = -inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = -inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                        
                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        
                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);*/
                        
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 180, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 180, turnSpeed));
                       // orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
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
                    {/*
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                        
                        Debug.Log(x);
                        Debug.Log(y);

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        */
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 270, turnSpeed));
                        //orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
                        break;
                    }
                    case true:
                    {/*
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        
                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        */
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.y, 0, turnSpeed), Mathf.Lerp(transform.eulerAngles.z, 90, turnSpeed));
                        //orientation.transform.rotation = Quaternion.Euler(0, -yRotation, 0);
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
                       /* float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        */
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, 90, turnSpeed), transform.eulerAngles.y, Mathf.Lerp(transform.eulerAngles.z, 0, turnSpeed));
                        //orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
                        break;
                    }
                    case true:
                    {
                        /*float x = -inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = -inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                        //todo 2 axes modification
                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        */
                        Debug.Log("test");
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x, -90, turnSpeed), transform.eulerAngles.y, transform.eulerAngles.z);
                        //orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
                        break;
                    }
                }
                break;
            }
        }
        
    }
    
}
