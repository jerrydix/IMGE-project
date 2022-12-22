using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput input;
    public Camera FPSCamera; 
    // Update is called once per frame
    private void Start()
    {
        input = new PlayerInput();
        input.Moving.Enable();
        input.Moving.Fire.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;
            if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.changeGravity();
                }
            }
        }
    }

    void Update()
    {
       /* if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }*/
    }
}