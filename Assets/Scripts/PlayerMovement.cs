using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpSpeed = 2f;
    private PlayerInput inputActions;

    /*[Header("Camera")]
    [SerializeField] private Camera cam;
    private float xRotation;
    private float yRotation;
    [SerializeField] private float xSensi;
    [SerializeField] private float ySensi;*/

    [Header("Ground")]
    [SerializeField] private float height;
    [SerializeField] private LayerMask ground;
    bool grounded;

    [Header("Movement")] 
    [SerializeField] private Transform orientation;
    [SerializeField] float drag;
    [SerializeField] private float airMult;
    public float jumpCooldown;
    private bool jump;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        jump = true;
        
        inputActions = new PlayerInput();
        inputActions.Moving.Enable();
        inputActions.Moving.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = inputActions.Moving.Move.ReadValue<Vector2>();
        Debug.Log(moveInput);
        Move(moveInput);
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.2f, ground);
        Debug.Log(grounded);
        SpeedLimit();
        if (grounded)
            _rigidbody.drag = drag;
        else
            _rigidbody.drag = 0;
    }

    private void LateUpdate()
    {
       // float x = inputActions.Moving.Look.ReadValue<Vector2>().x * Time.deltaTime * xSensi;
       // float y = inputActions.Moving.Look.ReadValue<Vector2>().y * Time.deltaTime * ySensi;

       // yRotation += x;
        //xRotation -= y;
        //xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        
        //cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void Move(Vector2 input)
    {
        Vector3 dir = orientation.forward * input.y + orientation.right * input.x;
        if(grounded)
            _rigidbody.AddForce(dir * moveSpeed * 10f, ForceMode.Force);
            
        else if(!grounded)
            _rigidbody.AddForce(dir * 10f * airMult, ForceMode.Force);
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && grounded && jump)
        {
            //_rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
            _rigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
            
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    
    private void ResetJump()
    {
        jump = true;
    }
    
    private void SpeedLimit()
    {
        Vector3 vel = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        
        if(vel.magnitude > moveSpeed)
        {
            Vector3 lim = vel.normalized * moveSpeed;
            _rigidbody.velocity = new Vector3(lim.x, _rigidbody.velocity.y, lim.z);
        }
    }
}
