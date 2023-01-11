using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform player, holder, orientation;
    [SerializeField] private float pickupRange, dropForceFront, dropForceUp;
    private Rigidbody _rb;
    [SerializeField] private PlayerShooting _func;
    [SerializeField] private BoxCollider _col;

    private PlayerInput _input;
    public bool equipped;
    
    private Vector3 dist;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GameObject.Find("Player").GetComponent<PlayerMovement>().inputActions;
        _input.Moving.Equip.performed += Equip;
        _input.Moving.Drop.performed += Drop;

        if (!equipped)
        {
            _func.enabled = false;
            _rb.isKinematic = false;
            _col.isTrigger = false;
        }
        else
        {
            _func.enabled = true;
            _rb.isKinematic = true;
            _col.isTrigger = true;
            //transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        dist = player.position - transform.position;
    }

    private void Equip(InputAction.CallbackContext context)
    {
        if (context.performed && !equipped && dist.magnitude <= pickupRange)
        {
            equipped = true;
            
            transform.SetParent(holder);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = new Vector3(0.01f,0.01f,0.01f);
            
            _rb.isKinematic = true;
            _col.isTrigger = true;
            _func.enabled = true;
        }
    }

    private void Drop(InputAction.CallbackContext context)
    {
        if (context.performed && equipped)
        {
            equipped = false;
            
            transform.SetParent(null);
            
            _rb.isKinematic = false;
            _col.isTrigger = false;
           // _rb.velocity = player.GetComponent<Rigidbody>().velocity;
            _rb.AddForce(orientation.forward * dropForceFront, ForceMode.Impulse);
            _rb.AddForce(orientation.up * dropForceUp, ForceMode.Impulse);
            float random = Random.Range(-1f, 1f);
            //_rb.AddTorque(new Vector3(random, random, random) * 10);

            _func.enabled = false;
        }
    }
}
