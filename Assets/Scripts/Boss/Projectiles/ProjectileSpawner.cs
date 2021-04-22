using System;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float shotInterval;
    [SerializeField] private bool tracksPlayer;
    [SerializeField] private float speed;
    
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
            {
                var playerHeight = new Vector3(transform.position.x, player.transform.position.y);
                transform.position = Vector3.Lerp(transform.position, playerHeight, Time.deltaTime * speed);

            }
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
                tracksPlayer = true;
                shotTime = shotInterval;
                material.color = Color.white;
            }
            else
            {
                tracksPlayer = false;
                material.color = Color.red;
                shotTime -= Time.deltaTime;
            }
        }
    }
}
