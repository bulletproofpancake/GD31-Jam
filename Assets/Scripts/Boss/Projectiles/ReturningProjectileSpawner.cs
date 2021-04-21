using System;
using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class ReturningProjectileSpawner : ProjectileSpawner
    {
        [SerializeField] private GameObject player;
        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            
        }

        public override void StartSpawning()
        {
            InvokeRepeating("SpawnProjectile", 1f, delayTime * 2 + 1f);
        }
        
        private void Update()
        {
            spawnPositions[0].position = new Vector3(spawnPositions[0].position.x, player.transform.position.y);
        }

        protected override IEnumerator SpawnCoroutine(GameObject projectile, Transform[] positions, float interval)
        {
            spawnPositions[0].position = new Vector3(spawnPositions[0].position.x, player.transform.position.y);
            yield return new WaitForSeconds(interval);
            Spawn(projectile, spawnPositions[0]);
        }
    }
}