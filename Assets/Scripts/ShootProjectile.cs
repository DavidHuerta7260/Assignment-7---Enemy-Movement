using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform firePoint;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject firedProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Destroy(firedProjectile, 3f);
    }
}