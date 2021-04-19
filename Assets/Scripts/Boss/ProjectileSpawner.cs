using System;
using UnityEngine;

namespace Boss
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform[] spawnPositions;


        private void Start()
        {
            Spawn(spawnPositions[0]);
        }

        private void Spawn(Transform spawnPosition)
        {
            Instantiate(projectile, spawnPosition.position, Quaternion.identity);
        }
        
    }
}