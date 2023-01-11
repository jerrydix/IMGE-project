using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int pressed = 0;
    [SerializeField] private Material lit;
    [SerializeField] private Material normal;
    [SerializeField] private GameObject buttonSide;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ButtonTrigger") || other.gameObject.CompareTag("Player"))
        {
            pressed++;
        }

        if (pressed > 0)
        {
            buttonSide.GetComponent<Renderer>().material = lit;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ButtonTrigger") || other.gameObject.CompareTag("Player"))
        {
            pressed--;
        }
        if (pressed == 0)
        {
            buttonSide.GetComponent<Renderer>().material = normal;
        }
    }
    
}
