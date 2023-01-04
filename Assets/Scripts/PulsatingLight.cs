using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PulsatingLight : MonoBehaviour
{
    [SerializeField] private bool blinking = false;
    [SerializeField] private Light light;
    [SerializeField] private float max = 14f;
    [SerializeField] private float min = 7f;
    private float t = 0f;
    
    private void Update()
    {
        if (blinking)
        {
            float r = Random.Range(0f, 1f);
            if (r > 0.01f)
            {
                light.intensity = max;
            }else{
                light.intensity = 0;
            }
        }
        else
        {
            float intensity = Mathf.Lerp(min, max, t);

            t += 1.1f * Time.deltaTime;

            light.intensity = intensity;
        
            if (t >= 1f)
            {
                (max, min) = (min, max);
                t = 0.0f;
            } 
        }
    }
}
    
