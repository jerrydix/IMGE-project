using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform camPos;
    private CameraMovement _movement;

    private void Awake()
    {
        _movement = GetComponentInChildren<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPos.position;
    }
}