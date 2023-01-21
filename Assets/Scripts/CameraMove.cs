using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private CameraHolderMove.FlipStatus status;
    [SerializeField] private Transform orientation;
    private PlayerInput inputActions;
    [HideInInspector] public bool flippedY;
    [HideInInspector] public bool flippedX;
    [HideInInspector] public bool flippedZ;
    
    private float xRotation;
    private float yRotation;
    
    public float xSensi;
    public float ySensi;
    [SerializeField] private float turnSpeed;

    private GameObject _pause;

    private void Awake()
    {
        inputActions = new PlayerInput();
    }

    private void Start()
    {
        xSensi = GameManager.Instance.currentSensitivity;
        ySensi = GameManager.Instance.currentSensitivity;
        status = GetComponentInParent<CameraHolderMove>().status;
        inputActions.Moving.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        flippedY = GetComponentInParent<CameraHolderMove>().flippedY;
        flippedX = GetComponentInParent<CameraHolderMove>().flippedX;
        flippedZ = GetComponentInParent<CameraHolderMove>().flippedZ;

        _pause = GameObject.Find("UI");
    }

    void Update()
    {
        if (_pause.GetComponent<PauseMenu>().active)
        {
            inputActions.Moving.Disable();
        }
        else
        {
            inputActions.Moving.Enable();
        }
        float x = 0;
        float y = 0;
        float rotZ = GetComponentInParent<CameraHolderMove>().zRotation;
        switch (rotZ)
        {
            case 0:
            {
                x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                break;
            }
            case 180:
            {
                x = -inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                y = -inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;
                break;
            }
        }
        
        
        yRotation += x;
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, Mathf.Lerp(transform.eulerAngles.z, GetComponentInParent<CameraHolderMove>().zRotation, turnSpeed * Time.deltaTime));
        
        orientation.rotation = Quaternion.Euler(orientation.rotation.x, transform.rotation.eulerAngles.y, orientation.rotation.y);
    }
}
