using System;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shotInterval;
    [SerializeField] private bool tracksPlayerVertical, tracksPlayerHorizontal;
    [SerializeField] private float speed;
    
    [HideInInspector] public bool isActive;
    
    private float shotTime;
    private GameObject player;
    private Material material;

    private bool horizontal, vertical;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        player = GameObject.FindWithTag("Player");
        shotTime = shotInterval;
        if(tracksPlayerVertical)
        {
            vertical = true;
            horizontal = false;
        }
        
        if (tracksPlayerHorizontal)
        {
            vertical = false;
            horizontal = true;
        }
    }

    private void Update()
    {
        if (tracksPlayerVertical)
        {
            if (player != null)
            {
                var playerHeight = new Vector3(transform.position.x, player.transform.position.y);
                transform.position = Vector3.Lerp(transform.position, playerHeight, Time.deltaTime * speed);

            }
        }
        if (tracksPlayerHorizontal)
        {
            if (player != null)
            {
                var playerWidth = new Vector3(player.transform.position.x, transform.position.y);
                transform.position = Vector3.Lerp(transform.position, playerWidth, Time.deltaTime * speed);
            }
        }
        if (isActive)
        {
            SpawnProjectiles();
        }
    }

    private void SpawnProjectiles()
    {
       if (shotTime <= 0)
       {
           Instantiate(prefab, spawnPoint.position, prefab.transform.rotation);
           isActive = false;
           if(vertical){
               tracksPlayerVertical = true;
           }
           if (horizontal)
           {
               tracksPlayerHorizontal = true;
           }
           shotTime = shotInterval;
           material.color = Color.white;
       }
       else
       {
           if(vertical){
               tracksPlayerVertical = false;
           }
           if (horizontal)
           {
               tracksPlayerHorizontal = false;
           }
           material.color = Color.red;
           shotTime -= Time.deltaTime;
       }
        
    }
}
