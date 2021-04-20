using System;
using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class HarpoonSpawner : ProjectileSpawner
    {
        [SerializeField] private GameObject player;
        protected override void Start()
        {
            player = GameObject.FindWithTag("Player");
            base.Start();
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