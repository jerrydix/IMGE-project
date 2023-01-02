using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private CameraHolderMove.FlipStatus status;
    [SerializeField] private Transform orientation;
    private PlayerInput inputActions;
    public bool flippedY;
    public bool flippedX;
    public bool flippedZ;
    
    private float xRotation = 0;
    private float yRotation = 0;
    
    [SerializeField] private float xSensi = 15f;
    [SerializeField] private float ySensi = 15f;
    [SerializeField] private float turnSpeed = 15f;

    private void Start()
    {
        status = GetComponentInParent<CameraHolderMove>().status;
        inputActions = inputActions = new PlayerInput();
        inputActions.Moving.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        flippedY = GetComponentInParent<CameraHolderMove>().flippedY;
        flippedX = GetComponentInParent<CameraHolderMove>().flippedX;
        flippedZ = GetComponentInParent<CameraHolderMove>().flippedZ;
    }

    void Update()
    {

        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
        
        yRotation += x;
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        //orientation.transform.rotation = Quaternion.Euler(orientation.eulerAngles.x, yRotation, orientation.eulerAngles.z);
        //if (flippedY)
        //{
            orientation.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);//Quaternion.Euler(transform.localRotation.eulerAngles.x, -transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        //}
        /*switch (status)
        {
            case CameraHolderMove.FlipStatus.Y:
            {
                switch (flippedY)
                {
                    case false:
                    {
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                        
                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        
                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
                        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
                        break;
                    }
                    case true:
                    {
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                        
                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        
                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
                        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
                        break;
                    }
                }
                break;
            }
            case CameraHolderMove.FlipStatus.X:
            {
                switch (flippedX)
                {
                    case false:
                    {
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                        
                        Debug.Log(x);
                        Debug.Log(y);

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.rotation = Quaternion.Euler(yRotation, xRotation, transform.rotation.z);
                        orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
                        break;
                    }
                    case true:
                    {
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        
                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                       // transform.rotation = Quaternion.Euler(-yRotation, xRotation, Mathf.Lerp(transform.eulerAngles.z, 90, turnSpeed));
                        orientation.transform.rotation = Quaternion.Euler(0, -yRotation, 0);
                        break;
                    }
                }
                break;
            }
            case CameraHolderMove.FlipStatus.Z:
            {
                switch (flippedZ)
                {
                    case false:
                    {
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.rotation = Quaternion.Euler(transform.rotation.z, xRotation, yRotation);
                        orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
                        break;
                    }
                    case true:
                    {
                        float x = -inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = -inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.rotation = Quaternion.Euler(transform.rotation.z, xRotation, yRotation);
                        orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
                        break;
                    }
                }
                break;
            }
        }*/
        
    }
}
