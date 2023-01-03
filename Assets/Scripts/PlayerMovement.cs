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
    [SerializeField] private Vector3 localGravity;

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

    [SerializeField] private CameraHolderMove cam;
    [SerializeField] private Transform cameraLookAt;

    Vector3 upAxis, rightAxis, forwardAxis;
    
    void Awake()
    {
        localGravity = new Vector3(0, -9.81f, 0);
        //_rigidbody.AddForce(0, 9.81f,0);
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
    
    Vector3 ProjectDirectionOnPlane (Vector3 direction, Vector3 normal) {
        return (direction - normal * Vector3.Dot(direction, normal)).normalized;
    }
    
    /*void AdjustVelocity () {
        Vector3 xAxis = ProjectDirectionOnPlane(rightAxis, contactNormal);
        Vector3 zAxis = ProjectDirectionOnPlane(forwardAxis, contactNormal);
    }*/

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
                localGravity = new Vector3(0, -9.81f, 0);
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
                localGravity = new Vector3(-9.81f, 0, 0);
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
                localGravity = new Vector3(0, 0, -9.81f);
        }
    }
    
    private void Move(Vector2 input)
    {

        Vector3 dir = new Vector3();

        dir = cameraLookAt.forward  * input.y + cameraLookAt.right * input.x;
        if (cam.flippedY)
            dir = cameraLookAt.forward * input.y +cameraLookAt.right * input.x; 
        
        /*switch (cam.status)
        {
            case CameraHolderMove.FlipStatus.Y:
            {
                dir = cameraLookAt.forward * input.y + cameraLookAt.right * input.x;
                if (cam.flippedY)
                    dir = cameraLookAt.forward * input.y + cameraLookAt.right * input.x; 
                break;
            }
            case CameraHolderMove.FlipStatus.X:
            {
                dir = cameraLookAt.forward  * input.y + cameraLookAt.right * input.x;
                if (cam.flippedY)
                    dir = cameraLookAt.forward * input.y +cameraLookAt.right * input.x; 
                break;
            }
            case CameraHolderMove.FlipStatus.Z:
            {
                dir = orientation.forward * input.y + orientation.right * input.x;
                if (cam.flippedY)
                    dir = orientation.forward * input.y + -orientation.right * input.x; 
                break;
            }
        }*/


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
