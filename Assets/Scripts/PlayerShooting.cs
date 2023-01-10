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
    [FormerlySerializedAs("FPSCamera")] public Camera fpsCamera;
    [SerializeField] public float gravity;
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
        StartCoroutine(GravityBrake());
    }

    private void ChangeGravityDirToX(InputAction.CallbackContext context)
    {
        xForce = true;

        zForce = false;

        yForce = false;
        StartCoroutine(GravityBrake());
    }

    private void ChangeGravityDirToZ(InputAction.CallbackContext context)
    {
        xForce = false;

        zForce = true;

        yForce = false;
        StartCoroutine(GravityBrake());
    }

    IEnumerator GravityBrake()
    {
        manipulatedObject.GetComponent<Rigidbody>().drag = 100000;
        yield return new WaitForSeconds(0.5f);
        manipulatedObject.GetComponent<Rigidbody>().drag = 0;
    }
}