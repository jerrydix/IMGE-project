using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField] private float smooth;
    [SerializeField] private float multiplier;
    
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * multiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * multiplier;
        
        Quaternion rotX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion combined = rotX * rotY;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler( combined.eulerAngles.x, combined.eulerAngles.y - 180, combined.eulerAngles.z), smooth * Time.deltaTime);
    }
}
