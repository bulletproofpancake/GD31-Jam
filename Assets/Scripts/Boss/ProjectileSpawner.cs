using System;
using System.Collections;
using UnityEngine;

namespace Boss
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float delayTime;
        [SerializeField] private Transform[] spawnPositions;

        private void Start()
        {
            StartCoroutine(SpawnCoroutine(prefab, spawnPositions, delayTime));
        }

        public void Spawn(GameObject projectile,Transform spawnPosition)
        {
            Instantiate(projectile, spawnPosition.position, Quaternion.identity);
        }

        private IEnumerator SpawnCoroutine(GameObject projectile, Transform[] positions, float interval)
        {
            foreach (var position in positions)
            {
                yield return new WaitForSeconds(interval);
                Instantiate(projectile, position.position, Quaternion.identity);
            }
        }
    }
}