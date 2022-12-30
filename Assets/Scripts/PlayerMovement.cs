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

    [SerializeField] private CameraMovement cam;

    Vector3 upAxis, rightAxis, forwardAxis;
    
    void Awake()
    {
        jumpSpeed = Mathf.Sqrt(Physics.gravity.magnitude * jumpSpeed);
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
        upAxis = -Physics.gravity.normalized;

        if (upAxis.Equals(Vector3.up))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            Debug.Log(transform.rotation);
            cam.flipped = false;
        } else if (upAxis.Equals(-Vector3.up)) {
            transform.rotation = Quaternion.Euler(180,0,0);
            Debug.Log(transform.rotation);
            cam.flipped = true;
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
    
    private void Move(Vector2 input)
    {
        Vector3 dir = /*ProjectDirectionOnPlane( */orientation.forward/*, upAxis)*/ * input.y + /*ProjectDirectionOnPlane(*/orientation.right/*, upAxis)*/ * input.x;
        if (cam.flipped)
            dir = /*ProjectDirectionOnPlane( */orientation.forward/*, upAxis)*/ * input.y + /*ProjectDirectionOnPlane(*/-orientation.right/*, upAxis)*/ * input.x; 
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
