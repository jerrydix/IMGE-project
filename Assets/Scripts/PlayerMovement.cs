using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform spawn;

    [Header("Movement")]
    private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpSpeed = 2f;
    public PlayerInput inputActions;
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
    
    private float runSoundTimer;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource stepsSource;
    [SerializeField] private AudioClip[] tutorialClips;
    [SerializeField] private AudioSource tutorialSource;
    private bool stepped;

    private Vector3 upAxis;
    private GameObject _pause;
    
    void Awake()
    {
        stepped = false;
        runSoundTimer = 0;
        localGravity = new Vector3(0, -gravity, 0);
        jumpSpeed = Mathf.Sqrt(Physics.gravity.magnitude * jumpSpeed);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        jump = true;
        
        inputActions = new PlayerInput();
        //transform.position = spawn.position;
    }
    
    IEnumerator SoundWaiter()
    {
        while (tutorialSource.isPlaying)
        {
            yield return null;
        }
        
        inputActions.Moving.Enable();
        inputActions.Moving.Jump.performed += Jump;
        inputActions.Moving.ChangeGravityY.performed += ChangeGravityY;
    }

    private void Start()
    {
        _pause = GameObject.Find("UI");
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            tutorialSource.PlayOneShot(tutorialClips[0]);
            StartCoroutine(SoundWaiter());
        }
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
        /*(if (_pause.GetComponent<PauseMenu>().active)
        {
            inputActions.Moving.Disable();
        }
        else
        {
            inputActions.Moving.Enable();
        }*/
        
        grounded = Physics.Raycast(transform.position, -upAxis, height * 0.5f + 0.2f, ground);
        SpeedLimit();
        if (grounded)
        {
            _rigidbody.drag = drag;
        }
        else {
            _rigidbody.drag = 0;
        }
        if (stepped)
        {
            runSoundTimer += Time.deltaTime;
            if (runSoundTimer >= 0.5)
            {
                runSoundTimer = 0;
                stepped = false;
            }
        }
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

    /*private void ChangeGravityX(InputAction.CallbackContext context)
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
    }*/
    
    private void Move(Vector2 input)
    {
        if (!stepped && input != new Vector2(0,0) && grounded) {
            stepped = true;
            stepsSource.PlayOneShot(clips[UnityEngine.Random.Range(0, clips.Length)]);
        }
        //todo cases for two axis
        Vector3 dir = new Vector3(cameraLookAt.forward.x, 0, cameraLookAt.forward.z).normalized * input.y + cameraLookAt.right.normalized * input.x;

        if(grounded)
            _rigidbody.AddForce(dir * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)
            _rigidbody.AddForce(dir * 10f * airMult, ForceMode.Force);
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && grounded && jump)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sounds.Jump);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("TutorialCol1"))
        {
            other.gameObject.SetActive(false);
            tutorialSource.Stop();
            tutorialSource.PlayOneShot(tutorialClips[1]);
        }
        
        if (other.gameObject.name.Equals("TutorialCol2"))
        {
            other.gameObject.SetActive(false);
            tutorialSource.Stop();
            tutorialSource.PlayOneShot(tutorialClips[2]);
        }
    }
}
