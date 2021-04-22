using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] protected GameObject prefab;
        [SerializeField] protected float delayTime;
        [SerializeField] protected Transform[] spawnPositions;
        public bool canSpawn;
        public float cooldownTime;   
        
        public virtual void StartSpawning()
        {
            if (!canSpawn) 
                StartCoroutine(CoolDown());
        }

        private IEnumerator CoolDown()
        {
            canSpawn = false;
            yield return new WaitForSeconds(cooldownTime);
            canSpawn = true;
            
            SpawnProjectile();
        }
        
        protected void SpawnProjectile()
        {
            StartCoroutine(SpawnCoroutine(prefab, spawnPositions, delayTime));
        }

        protected virtual IEnumerator SpawnCoroutine(GameObject projectile, Transform[] positions, float interval)
        {
            foreach (var position in positions)
            {
                yield return new WaitForSeconds(interval);
                Spawn(projectile, position);
            }
        }
        
        protected void Spawn(GameObject projectile,Transform spawnPosition)
        {
            Instantiate(projectile, spawnPosition.position, Quaternion.identity);
        }
    }
}