using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class PlayerShooting : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] public Camera fpsCamera;
    [SerializeField] public float gravity;
    [SerializeField] private TrailRenderer trail;
    private float mouseScrollY;
    GameObject manipulatedObject;
    private bool yForce = true;
    private bool zForce = false;
    private bool xForce = false;


    private void Start()
    {
        input = new PlayerInput();
        input.Moving.Enable();
        input.Moving.Fire.performed += Shoot;
        input.Moving.Scrolled.performed += ScrollToGravityValue;
        input.Moving.Scrolled.performed += x => mouseScrollY = x.ReadValue<float>();
        input.Moving.GunGravityX.performed += ChangeGravityDirToX;
        input.Moving.GunGravityY.performed += ChangeGravityDirToY;
        input.Moving.GunGravityZ.performed += ChangeGravityDirToZ;


        gravity = 0f;
    }


    private void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out var hit, 100))
            {
                manipulatedObject = hit.transform.GameObject(); 
                if (manipulatedObject.GetComponent<Target>() != null)
                {
                    Target target = manipulatedObject.GetComponent<Target>();
                    if (target != null)
                    {
                        target.ChangeGravity();
                    }
                }
            }
        }
    }

    private void ScrollToGravityValue(InputAction.CallbackContext context)
    {
        if (mouseScrollY > 0)
        {
            gravity += 0.0981f;
        }

        if (mouseScrollY < 0)
        {
            gravity -= 0.0981f;
        }

        if (!manipulatedObject.IsUnityNull())
        {
            if (manipulatedObject.GetComponent<ConstantForce>() != null)
            {
                if (xForce)
                {
                    manipulatedObject.GetComponent<Rigidbody>().useGravity = false;
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(gravity / 10, 0, 0);
                }

                if (yForce)
                {
                    manipulatedObject.GetComponent<Rigidbody>().useGravity = true;
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, gravity + 9.81f, 0);
                }

                if (zForce)
                {
                    manipulatedObject.GetComponent<Rigidbody>().useGravity = false;
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, 0, gravity / 10);
                }
            }
        }
    }

    private void ChangeGravityDirToY(InputAction.CallbackContext context)
    {
        xForce = false;

        zForce = false;

        yForce = true;

        TrailRenderer trail = Instantiate(this.trail,
            manipulatedObject.transform.position - new Vector3(-0f, -3f, 0f), Quaternion.identity);
        Vector3 targetPosition = manipulatedObject.transform.position - new Vector3(0f, 3f, 0f);
        StartCoroutine(SpawnTrail(trail, targetPosition));
        
        gravity = 0;
        manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;
        
        StartCoroutine(GravityBrake());
    }

    private void ChangeGravityDirToX(InputAction.CallbackContext context)
    {
        xForce = true;

        zForce = false;

        yForce = false;
        
        TrailRenderer trail = Instantiate(this.trail,
            manipulatedObject.transform.position - new Vector3(-3f, 0f, 0f), Quaternion.identity);
        Vector3 targetPosition = manipulatedObject.transform.position - new Vector3(3f, 0f, 0f);
        StartCoroutine(SpawnTrail(trail, targetPosition));

        gravity = 0;
        manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;
        
        StartCoroutine(GravityBrake());
    }

    private void ChangeGravityDirToZ(InputAction.CallbackContext context)
    {
        xForce = false;

        zForce = true;

        yForce = false;
        
        TrailRenderer trail = Instantiate(this.trail,
            manipulatedObject.transform.position - new Vector3(0f, 0f, -3f), Quaternion.identity);
        Vector3 targetPosition = manipulatedObject.transform.position - new Vector3(0f, 0f, 3f);
        StartCoroutine(SpawnTrail(trail, targetPosition));
        
        gravity = 0;
        manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;
        
        StartCoroutine(GravityBrake());
    }


    /*
     * Spawns the trail
     */
    private IEnumerator SpawnTrail(TrailRenderer trail, Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, targetPosition, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }
        
        Destroy(trail.gameObject, trail.time);
    }
    
    IEnumerator GravityBrake()
    {
        manipulatedObject.GetComponent<Rigidbody>().drag = 100000;
        yield return new WaitForSeconds(0.5f);
        manipulatedObject.GetComponent<Rigidbody>().drag = 0;
    }
}