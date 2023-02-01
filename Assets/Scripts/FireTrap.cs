using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private bool _attack;
    [SerializeField] private int damage;
    [SerializeField] private float timeInterval;
    // Start is called before the first frame update
    void Start()
    {
        _attack = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _attack)
        {
            StartCoroutine(Attack());
            if (!other.GetComponent<HealthManager>().dead)
                other.GetComponent<HealthManager>().Damage(damage, HealthManager.DamageType.Normal);
        }
    }

    IEnumerator Attack()
    {
        _attack = false;
        yield return new WaitForSeconds(timeInterval);
        _attack = true;
    }
}
