using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform fpsCam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var cam = other.GetComponent<PlayerMovement>().cam;
            cam.flippedX = false;
            cam.flippedY = false;
            cam.flippedZ = false;
            cam.status = CameraHolderMove.FlipStatus.Y;
            other.transform.position = spawnPoint.position;
            fpsCam.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
