using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private CameraHolderMove.FlipStatus status;
    [SerializeField] private Transform orientation;
    private PlayerInput inputActions;
    [HideInInspector] public bool flippedY;
    [HideInInspector] public bool flippedX;
    [HideInInspector] public bool flippedZ;
    
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
        
        orientation.rotation = Quaternion.Euler(orientation.rotation.x, transform.rotation.eulerAngles.y, orientation.rotation.y);
    }
}
