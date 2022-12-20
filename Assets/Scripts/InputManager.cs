using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerInput.MovingActions _movingActions;
    private PlayerMovement _movement;
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInput();
        _movingActions = _input.Moving;
        _movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _movement.Movement(_movingActions.Move.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _movingActions.Enable();
    }

    private void OnDisable()
    {
        _movingActions.Disable();
    }
}
