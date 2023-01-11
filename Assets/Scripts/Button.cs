using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int pressed = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ButtonTrigger") || other.gameObject.CompareTag("Player"))
        {
            pressed++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ButtonTrigger") || other.gameObject.CompareTag("Player"))
        {
            pressed--;
        }
    }
    
}
