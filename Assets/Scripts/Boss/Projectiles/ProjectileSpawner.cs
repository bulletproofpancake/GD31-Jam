using System;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float shotInterval;
    [SerializeField] private bool tracksPlayer;
    
    public bool isActive;
    private float shotTime;
    private GameObject player;
    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        player = GameObject.FindWithTag("Player");
        shotTime = shotInterval;
    }

    private void Update()
    {
        if (tracksPlayer)
        {
            if (player != null)
                transform.position = new Vector3(transform.position.x, player.transform.position.y);
        }
        if (isActive)
        {
            SpawnProjectiles();
        }
    }

    private void SpawnProjectiles()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            if (shotTime <= 0)
            {
                Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                isActive = false;
                shotTime = shotInterval;
                material.color = Color.white;
            }
            else
            {
                material.color = Color.red;
                shotTime -= Time.deltaTime;
            }
        }
    }
}
