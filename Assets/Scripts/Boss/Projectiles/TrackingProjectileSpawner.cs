using System;
using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class TrackingProjectileSpawner : ProjectileSpawner
    {
        private GameObject _player;
        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            
        }

        public override void StartSpawning()
        {
            SpawnProjectile();
        }
        
        private void Update()
        {
            spawnPositions[0].position = new Vector3(spawnPositions[0].position.x, _player.transform.position.y);
        }

        protected override IEnumerator SpawnCoroutine(GameObject projectile, Transform[] positions, float interval)
        {
            spawnPositions[0].position = new Vector3(spawnPositions[0].position.x, _player.transform.position.y);
            yield return new WaitForSeconds(interval);
            Spawn(projectile, spawnPositions[0]);
        }
    }
}