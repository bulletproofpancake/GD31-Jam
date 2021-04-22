using System;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float cooldown, shotInterval;
    [SerializeField] private bool tracksPlayer;
    
    public bool isActive;
    private float shotTime;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
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
            }
            else
            {
                shotTime -= Time.deltaTime;
            }
        }
    }
}
