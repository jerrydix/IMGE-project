using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerInput inputActions;
    private float xRotation = 0;
    private float yRotation = 0;
    
    [SerializeField] private Transform player;
    
    [SerializeField] private float xSensi = 15f;
    [SerializeField] private float ySensi = 15f;
    public bool flipped;
    
    // Start is called before the first frame update
    void Start()
    {
        inputActions = inputActions = new PlayerInput();
        inputActions.Moving.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flipped)
        {
            float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
            float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

            yRotation += x;
            xRotation -= y;
            xRotation = Mathf.Clamp(xRotation, -80f, 58f);
        
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else
        {
            float x = -inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
            float y = -inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

            yRotation += x;
            xRotation -= y;
            xRotation = Mathf.Clamp(xRotation, -80f, 58f);
        
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 180);
            player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
