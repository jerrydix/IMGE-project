using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogic : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;

    bool firing;
    float fireTimer;

    int gunPointIndex;
    
    void Update()
    {
        if (firing)
        {
            while (fireTimer >= 1 / fireRate)
            {
                SoundManager.Instance.PlaySound(SoundManager.Sounds.TurretShoot);
                SpawnProjectile();
                fireTimer -= 1 / fireRate;
            }

            fireTimer += Time.deltaTime;
            firing = false;
        }
        else
        {
            if (fireTimer < 1 / fireRate)
            {
                fireTimer += Time.deltaTime;
            }
            else
            {
                fireTimer = 1 / fireRate;
            }
        }
    }

    void SpawnProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    public void Shoot()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, Mathf.Infinity) && hit.collider.CompareTag("Player"))
            firing = true;
    }
}
