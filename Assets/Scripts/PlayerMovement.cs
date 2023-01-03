using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform spawn;

    [Header("Movement")]
    private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpSpeed = 2f;
    private PlayerInput inputActions;
    private Vector3 localGravity;
    [SerializeField] float drag;
    [SerializeField] private float airMult;
    public float jumpCooldown;
    private bool jump;
    [SerializeField] private float gravity;

    [Header("Ground")]
    [SerializeField] private float height;
    [SerializeField] private LayerMask ground;
    bool grounded;

    [Header("Camera")]
    [SerializeField] public CameraHolderMove cam;
    [SerializeField] private Transform cameraLookAt;

    private Vector3 upAxis;
    
    void Awake()
    {
        localGravity = new Vector3(0, -gravity, 0);
        jumpSpeed = Mathf.Sqrt(Physics.gravity.magnitude * jumpSpeed);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        jump = true;
        
        inputActions = new PlayerInput();
        inputActions.Moving.Enable();
        inputActions.Moving.Jump.performed += Jump;
        inputActions.Moving.ChangeGravityY.performed += ChangeGravityY;
        inputActions.Moving.ChangeGravityX.performed += ChangeGravityX;
        inputActions.Moving.ChangeGravityZ.performed += ChangeGravityZ;

        transform.position = spawn.position;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(localGravity);
        Vector2 moveInput = inputActions.Moving.Move.ReadValue<Vector2>();
        upAxis = -localGravity.normalized;

        //todo slerp rotation
        if (upAxis.Equals(Vector3.up))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            cam.flippedY = false;
        } else if (upAxis.Equals(-Vector3.up)) {
            transform.rotation = Quaternion.Euler(180,0,0);
            cam.flippedY = true;
        }

        if (upAxis.Equals(Vector3.right))
        {
            transform.rotation = Quaternion.Euler(0,0,-90);
            cam.flippedX = false;
        } else if (upAxis.Equals(-Vector3.right))
        {
            transform.rotation = Quaternion.Euler(0,0,90);
            cam.flippedX = true;
        }
        
        if (upAxis.Equals(Vector3.forward))
        {
            transform.rotation = Quaternion.Euler(90,0,0);
            cam.flippedZ = false;
        } else if (upAxis.Equals(-Vector3.forward))
        {
            transform.rotation = Quaternion.Euler(-90,0,0);
            cam.flippedZ = true;
        }
        Move(moveInput);
    }
    
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, -upAxis, height * 0.5f + 0.2f, ground);
        SpeedLimit();
        if (grounded)
            _rigidbody.drag = drag;
        else
            _rigidbody.drag = 0;
    }

    private void ChangeGravityY(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cam.status = CameraHolderMove.FlipStatus.Y;
            if (localGravity.y < 0)
            {
                localGravity.y *= -1;
            } else
                localGravity = new Vector3(0, -gravity, 0);
        }
    }

    private void ChangeGravityX(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cam.status = CameraHolderMove.FlipStatus.X;
            if (localGravity.x < 0)
            {
                localGravity.x *= -1;
            } else
                localGravity = new Vector3(-gravity, 0, 0);
        }
    }
    
    private void ChangeGravityZ(InputAction.CallbackContext context)
    {
        cam.status = CameraHolderMove.FlipStatus.Z;
        if (context.performed)
        {
            if (localGravity.z < 0)
            {
                localGravity.z *= -1;
            } else
                localGravity = new Vector3(0, 0, -gravity);
        }
    }
    
    private void Move(Vector2 input)
    {

        Vector3 dir = new Vector3();

        dir = cameraLookAt.forward  * input.y + cameraLookAt.right * input.x;
        if (cam.flippedY)
            dir = cameraLookAt.forward * input.y +cameraLookAt.right * input.x; 
        
        if(grounded)
            _rigidbody.AddForce(dir * moveSpeed * 10f, ForceMode.Force);
            
        else if(!grounded)
            _rigidbody.AddForce(dir * 10f * airMult, ForceMode.Force);
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && grounded && jump)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
            _rigidbody.AddForce(upAxis * jumpSpeed, ForceMode.Impulse);
            
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
