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
    [SerializeField] private float gravity;
    private float mouseScrollY;
    GameObject manipulatedObject;

    private void Start()
    {
        input = new PlayerInput();
        input.Moving.Enable();
        input.Moving.Fire.performed += Shoot;
        input.Moving.Scrolled.performed += ScrollToGravityValue;
        input.Moving.Scrolled.performed += x => mouseScrollY = x.ReadValue<float>();

        gravity = 9.81f;
    }


    private void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out var hit, 100))
            {
                manipulatedObject = hit.transform.GameObject();
                Target target = manipulatedObject.GetComponent<Target>();
                if (target != null)
                {
                    target.ChangeGravity();
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
            manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, gravity, 0);
        }
    }
}