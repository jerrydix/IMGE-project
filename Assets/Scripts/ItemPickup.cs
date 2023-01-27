using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform player, holder, orientation;
    [SerializeField] private Transform genHolder;
    [SerializeField] private float pickupRange, dropForceFront, dropForceUp;
    private Rigidbody _rb;
    [SerializeField] private PlayerShooting _func;
    [SerializeField] private Collider _col;

    private PlayerInput _input;
    public bool equipped;
    public bool genPart;
    
    private Vector3 dist;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<GeneratorPiece>() != null)
        {
            genPart = true;
        }
        _rb = GetComponent<Rigidbody>();
        _input = GameObject.Find("Player").GetComponent<PlayerMovement>().inputActions;
        _input.Moving.Equip.performed += Equip;
        _input.Moving.Drop.performed += Drop;

        if (!equipped)
        {
            if (!genPart)
                _func.enabled = false;
            _rb.isKinematic = false;
            _col.isTrigger = false;
        }
        else
        {
            if (!genPart)
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
        if (SceneManager.GetActiveScene().name == "BackedNikkiScene" && equipped)
        {
            GameObject.Find("LevelChanger").GetComponent<LevelChanger>().Fade();
        }
    }

    private void Equip(InputAction.CallbackContext context)
    {
        if (context.performed && !equipped && dist.magnitude <= pickupRange)
        {
            equipped = true;

            if (genPart)
                transform.SetParent(genHolder);
            else
            {
                transform.SetParent(holder);
                _func.enabled = true;
            }
            
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            if (genPart)
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            else
                transform.localScale = new Vector3(0.01f,0.01f,0.01f);
            
            _rb.isKinematic = true;
            _col.isTrigger = true;
        }
    }

    private void Drop(InputAction.CallbackContext context)
    {
        if (context.performed && equipped && genPart)
        {
            equipped = false;
            transform.SetParent(null);
            
            if (genPart)
                transform.localScale = new Vector3(1f, 1f, 1f);
            _rb.isKinematic = false;
            _col.isTrigger = false;
           // _rb.velocity = player.GetComponent<Rigidbody>().velocity;
            _rb.AddForce(orientation.forward * dropForceFront, ForceMode.Impulse);
            _rb.AddForce(orientation.up * dropForceUp, ForceMode.Impulse);
            float random = Random.Range(-1f, 1f);
            //_rb.AddTorque(new Vector3(random, random, random) * 10);
        }
    }
}
