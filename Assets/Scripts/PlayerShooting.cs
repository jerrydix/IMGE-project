using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class PlayerShooting : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] public Camera fpsCamera;
    [SerializeField] public float gravity;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private Material noOutLine;
    [SerializeField] private Material outLine;
    private float mouseScrollY;
    GameObject manipulatedObject;
    private bool yForce = true;
    private bool zForce = false;
    private bool xForce = false;
    [HideInInspector] public float currentForce;

    [SerializeField] private float _forceMultiplier = 0.5f;
    [HideInInspector] public float[] _force;
    public int _pointer;

    [SerializeField] private GameObject _particles;

    private void Awake()
    {
        input = new PlayerInput();
        input.Moving.Enable();
        input.GravityGun.Enable();

        /*
        input.Moving.Scrolled.performed += ScrollToGravityValue;
        input.Moving.Scrolled.performed += x => mouseScrollY = x.ReadValue<float>();
        input.Moving.GunGravityX.performed += ChangeGravityDirToX;
        input.Moving.GunGravityY.performed += ChangeGravityDirToY;
        input.Moving.GunGravityZ.performed += ChangeGravityDirToZ;
        */
        input.GravityGun.Fire.performed += Shoot;
        input.GravityGun.GravityDown.performed += ChangeNegativGravity;
        input.GravityGun.GravityUp.performed += ChangePositivGravity;
        input.GravityGun.ChangeGravityDirection.performed += GravDirChange;
        
        _force = new float[] { _forceMultiplier * -9.81f, 
                                _forceMultiplier * -6.54f,
                                _forceMultiplier * -3.27f,
                                0,
                                _forceMultiplier * 3.27f, 
                                _forceMultiplier * 6.54f,
                                _forceMultiplier * 9.81f };
        _pointer = 3;
        currentForce = _force[_pointer];

        gravity = 0f;
    }

    private void Update()
    {
        currentForce = _force[_pointer];
    }


    private void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out var hit, 100))
            {
                if (hit.transform.GameObject().GetComponent<Target>() != null)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Sounds.GunShoot);
                    if (manipulatedObject != null)
                    {
                        manipulatedObject.GetComponent<Renderer>().material = noOutLine;
                    }

                    if (manipulatedObject == hit.transform.GameObject())
                    {
                        _particles.SetActive(false);
                        manipulatedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;
                        gravity = 0f;
                        manipulatedObject = null;
                    }
                    else
                    {
                        _particles.SetActive(true);
                        manipulatedObject = hit.transform.GameObject();
                        manipulatedObject.GetComponent<Renderer>().material = outLine;

                        manipulatedObject.GetComponent<Rigidbody>().useGravity = true;

                        gravity = 0f;

                        if (xForce)
                        {
                            xTrail();
                        }
                        else if (zForce)
                        {
                            zTrail();
                        }
                        else if (yForce)
                        {
                            yTrail();
                        }

                        manipulatedObject.GetComponent<Rigidbody>().constraints =
                            RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;

                        //manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, gravity + 9.81f, 0);

                        Target target = manipulatedObject.GetComponent<Target>();
                        if (target != null)
                        {
                            target.ChangeGravity();
                        }
                    }
                }
            }
        }
    }

    /*
    private void ScrollToGravityValue(InputAction.CallbackContext context)
    {
        if (mouseScrollY > 0)
        {
            gravity += 0.0981f;
        }

        if (mouseScrollY < 0)
        {
            gravity -= 0.0981f;
        }

        if (!manipulatedObject.IsUnityNull())
        {
            if (manipulatedObject.GetComponent<ConstantForce>() != null)
            {
                if (xForce)
                {
                    manipulatedObject.GetComponent<Rigidbody>().useGravity = false;
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(gravity / 10, 0, 0);
                }

                if (yForce)
                {
                    manipulatedObject.GetComponent<Rigidbody>().useGravity = true;
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, gravity + 9.81f, 0);
                }

                if (zForce)
                {
                    manipulatedObject.GetComponent<Rigidbody>().useGravity = false;
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, 0, gravity / 10);
                }
            }
        }
    }

    private void ChangeGravityDirToY(InputAction.CallbackContext context)
    {
        if (manipulatedObject != null)
        {
            xForce = false;

            zForce = false;

            yForce = true;

            TrailRenderer trail = Instantiate(this.trail,
                manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, -3f, 0f),
                Quaternion.identity);
            Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 3f, 0f);
            StartCoroutine(SpawnTrail(trail, targetPosition));

            gravity = 0;
            manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;

            StartCoroutine(GravityBrake());
        }
    }

    private void ChangeGravityDirToX(InputAction.CallbackContext context)
    {
        if (manipulatedObject != null)
        {
            xForce = true;

            zForce = false;

            yForce = false;

            TrailRenderer trail = Instantiate(this.trail,
                manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(-3f, 0f, 0f),
                Quaternion.identity);
            Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(3f, 0f, 0f);
            StartCoroutine(SpawnTrail(trail, targetPosition));

            gravity = 0;
            manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;

            StartCoroutine(GravityBrake());
        }
    }

    private void ChangeGravityDirToZ(InputAction.CallbackContext context)
    {
        if (manipulatedObject != null)
        {
            xForce = false;

            zForce = true;

            yForce = false;

            TrailRenderer trail = Instantiate(this.trail,
                manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 0f, -3f),
                Quaternion.identity);
            Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 0f, 3f);
            StartCoroutine(SpawnTrail(trail, targetPosition));
            gravity = 0;
            manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;

            StartCoroutine(GravityBrake());
        }
    }
*/

    private void ChangeNegativGravity(InputAction.CallbackContext context)
    {
        if (context.performed && _pointer > 0 && manipulatedObject != null)
        {
            _pointer--;
            gravity = _force[_pointer];
            if (manipulatedObject.GetComponent<ConstantForce>() != null)
            {
                if (xForce)
                {
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(_force[_pointer], 9.81f, 0);
                }

                if (yForce)
                {
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, _force[_pointer] + 9.81f, 0);
                }

                if (zForce)
                {
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, 9.81f, _force[_pointer]);
                }
            }
        }
    }

    private void ChangePositivGravity(InputAction.CallbackContext context)
    {
        if (context.performed && _pointer < 6 && manipulatedObject != null)
        {
            _pointer++;
            gravity = _force[_pointer];
            if (manipulatedObject.GetComponent<ConstantForce>() != null)
            {
                if (xForce)
                {
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(_force[_pointer], 9.81f, 0);
                }

                if (yForce)
                {
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, _force[_pointer] + 9.81f, 0);
                }

                if (zForce)
                {
                    manipulatedObject.GetComponent<ConstantForce>().force = new Vector3(0, 9.81f, _force[_pointer]);
                }
            }
        }
    }

    private void GravDirChange(InputAction.CallbackContext context)
    {
        if (context.performed && manipulatedObject != null)
        {
            // Change to Y Direction
            if (xForce)
            {
                xForce = false;
                yForce = true;

                yTrail();
                StartCoroutine(GravityBrake());
            }
            // Change to Z Direction
            else if (yForce)
            {
                yForce = false;
                zForce = true;

                zTrail();
                StartCoroutine(GravityBrake());
            }
            // Change to X Direction
            else
            {
                zForce = false;
                xForce = true;

                xTrail();
                StartCoroutine(GravityBrake());
            }

            _pointer = 3;
        }
    }


    /*
     * Spawns the trail
     */
    private void zTrail()
    {
        TrailRenderer trail = Instantiate(this.trail,
            manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 0f, -3f),
            Quaternion.identity);
        Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 0f, 3f);
        StartCoroutine(SpawnTrail(trail, targetPosition));
    }

    private void yTrail()
    {
        TrailRenderer trail = Instantiate(this.trail,
            manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, -3f, 0f),
            Quaternion.identity);
        Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(0f, 3f, 0f);
        StartCoroutine(SpawnTrail(trail, targetPosition));
    }

    private void xTrail()
    {
        TrailRenderer trail = Instantiate(this.trail,
            manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(-3f, 0f, 0f),
            Quaternion.identity);
        Vector3 targetPosition = manipulatedObject.GetComponent<Renderer>().bounds.center - new Vector3(3f, 0f, 0f);
        StartCoroutine(SpawnTrail(trail, targetPosition));
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, targetPosition, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }

        Destroy(trail.gameObject, trail.time);
    }

    IEnumerator GravityBrake()
    {
        manipulatedObject.GetComponent<ConstantForce>().force = Vector3.zero;
        manipulatedObject.GetComponent<Rigidbody>().drag = 100;
        yield return new WaitForSeconds(0.5f);
        manipulatedObject.GetComponent<Rigidbody>().drag = 0;
    }
}