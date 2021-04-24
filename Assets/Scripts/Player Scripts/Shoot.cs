using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireRate = 1f;
    private float nextFire = 0;

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.X) && Time.time > nextFire) 
           {
            nextFire = Time.time + fireRate;
            shoot();
           }

    }

    private void shoot()
    {
        FindObjectOfType<Audio>().Play("shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
