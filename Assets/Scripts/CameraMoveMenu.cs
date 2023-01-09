using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveMenu : MonoBehaviour
{
    public Transform endMarker = null;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endMarker.position, Time.deltaTime);
    }
}
