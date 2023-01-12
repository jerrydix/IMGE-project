using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.Toon;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class PlayerShooting : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] public Camera fpsCamera;
    [SerializeField] public float gravity;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private Material noOutLine;
    [SerializeField] private Material outLine;
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
                if (hit.transform.GameObject().GetComponent<Target>() != null)
                {
                    if(manipulatedObject != null) {
                        manipulatedObject.GetComponent<Renderer>().material = noOutLine;
                    }

                    if (manipulatedObject == hit.transform.GameObject())
                    {
                        manipulatedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;
                        gravity = 0f;
                        manipulatedObject = null;
                    }
                    else
                    {
                        manipulatedObject = hit.transform.GameObject();
                        manipulatedObject.GetComponent<Renderer>().material = outLine;
                        
                        TrailRenderer trail = Instantiate(this.trail,
                            manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, -3f, 0f), Quaternion.identity);
                        Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 3f, 0f);
                        StartCoroutine(SpawnTrail(trail, targetPosition));

                        manipulatedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
                    
                        manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, gravity + 9.81f, 0);
                        
                        Target target = manipulatedObject.GetComponent<Target>();
                        if (target != null)
                        {
                            target.ChangeGravity();
                        }
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
        if(manipulatedObject != null) {
            xForce = false;

            zForce = false;

            yForce = true;

            TrailRenderer trail = Instantiate(this.trail,
                manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, -3f, 0f), Quaternion.identity);
            Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 3f, 0f);
            StartCoroutine(SpawnTrail(trail, targetPosition));
            
            gravity = 0;
            manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;
            
            StartCoroutine(GravityBrake());
        }
    }

    private void ChangeGravityDirToX(InputAction.CallbackContext context)
    {
        if (manipulatedObject != null)
        {
            xForce = true;

            zForce = false;

            yForce = false;

            TrailRenderer trail = Instantiate(this.trail,
                manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(-3f, 0f, 0f),
                Quaternion.identity);
            Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(3f, 0f, 0f);
            StartCoroutine(SpawnTrail(trail, targetPosition));

            gravity = 0;
            manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;

            StartCoroutine(GravityBrake());
        }
    }

    private void ChangeGravityDirToZ(InputAction.CallbackContext context)
    {
        if (manipulatedObject != null)
        {
            xForce = false;

            zForce = true;

            yForce = false;

            TrailRenderer trail = Instantiate(this.trail,
                manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 0f, -3f),
                Quaternion.identity);
            Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 0f, 3f);
            StartCoroutine(SpawnTrail(trail, targetPosition));

            gravity = 0;
            manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;

            StartCoroutine(GravityBrake());
        }
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