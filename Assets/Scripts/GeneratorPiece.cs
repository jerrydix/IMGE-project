using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPiece : MonoBehaviour
{
    public enum GeneratorPart
    {
        Battery,
        Motor,
        Pipe,
        Cables
    }

    [SerializeField] public GeneratorPart kind;
    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //todo if level complete and object equipped then...
        switch (kind)
        {
            case GeneratorPart.Battery:
                GameManagement.Instance.battery = true;
                break;
            case GeneratorPart.Motor:
                GameManagement.Instance.motor = true;
                break;
            case GeneratorPart.Pipe:
                GameManagement.Instance.pipe = true;
                break;
            case GeneratorPart.Cables:
                GameManagement.Instance.cables = true;
                break;
        }
    }
}
