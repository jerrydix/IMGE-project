using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum FlipStatus
    {
        X,
        Y,
        Z
    }
    private PlayerInput inputActions;
    private float xRotation = 0;
    private float yRotation = 0;
    [HideInInspector] public FlipStatus status;
    
    [SerializeField] private Transform orientation;
    
    [SerializeField] private float xSensi = 15f;
    [SerializeField] private float ySensi = 15f;
    [SerializeField] private float turnSpeed = .01f;
    public bool flippedY;
    public bool flippedX;
    public bool flippedZ;
    
    // Start is called before the first frame update
    void Start()
    {
        status = FlipStatus.Y;
        inputActions = inputActions = new PlayerInput();
        inputActions.Moving.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.rotation = Quaternion.Euler(xRotation, yRotation, Mathf.Lerp(transform.eulerAngles.z, 0, turnSpeed));
                        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
                        break;
                    }
                    case true:
                    {
                        float x = -inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = -inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.rotation = Quaternion.Euler(xRotation, yRotation, Mathf.Lerp(transform.eulerAngles.z, 180, turnSpeed));
                        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
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
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.rotation = Quaternion.Euler(yRotation, xRotation, Mathf.Lerp(transform.eulerAngles.z, -90, turnSpeed));
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
                        
                        transform.rotation = Quaternion.Euler(yRotation, xRotation, Mathf.Lerp(transform.eulerAngles.z, 90, turnSpeed));
                        orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
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
                        float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
                        float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

                        yRotation += x;
                        xRotation -= y;
                        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                        
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.z, 90, turnSpeed), xRotation, yRotation);
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
                        
                        transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.z, 90, turnSpeed), xRotation, yRotation);
                        orientation.transform.rotation = Quaternion.Euler(0, xRotation, 0);
                        break;
                    }
                }
                break;
            }
        }
        
    }
    
}
