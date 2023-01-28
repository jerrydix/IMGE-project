using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    [SerializeField] private Vector3 checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OutOfMapCollider"))
        {
            transform.position = checkpoint;
        } else if (other.CompareTag("Checkpoint"))
        {
            checkpoint = other.transform.position;
        }
    }

    public void Respawn()
    {
        transform.position = checkpoint;
    }
}
