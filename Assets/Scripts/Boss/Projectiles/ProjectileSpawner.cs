using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
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
        
        private IEnumerator SpawnCoroutine(GameObject projectile, Transform[] positions, float interval)
        {
            foreach (var position in positions)
            {
                yield return new WaitForSeconds(interval);
                Spawn(projectile, position);
            }
        }
        
        private void Spawn(GameObject projectile,Transform spawnPosition)
        {
            Instantiate(projectile, spawnPosition.position, Quaternion.identity);
        }
    }
}