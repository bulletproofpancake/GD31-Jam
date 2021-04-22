using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            shoot();
        }
    }

    private void shoot()
    {
        FindObjectOfType<Audio>().Play("shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
