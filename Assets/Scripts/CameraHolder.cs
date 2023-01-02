using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform camPos;
    //private CameraHolderMove _movement;

    private void Awake()
    {
        //_movement = GetComponentInChildren<CameraHolderMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPos.position;
    }
}