using System;
using UnityEngine;

namespace Boss.Projectiles
{
    public class BossAttack : MonoBehaviour
    {
        [SerializeField] private ProjectileSpawner harpoonSpawner;
        [SerializeField] private ProjectileSpawner geyserSpawner;
        [SerializeField] private float harpoonRange,geyserRange;
        [SerializeField] private LayerMask playerLayer;
        
        private void Update()
        {
            ShootHarpoon();
            ShootGeyser();
        }

        void ShootHarpoon()
        {
            var ray = new Ray(harpoonSpawner.transform.position, Vector3.left);
            Debug.DrawRay(ray.origin, ray.direction*harpoonRange, Color.green);
            if (Physics.Raycast(ray,harpoonRange,playerLayer))
            {
                Debug.DrawRay(ray.origin, ray.direction*harpoonRange, Color.red);
                harpoonSpawner.isActive = true;
            }
        }

        void ShootGeyser()
        {
            var ray = new Ray(geyserSpawner.transform.position, Vector3.up);
            Debug.DrawRay(ray.origin, ray.direction * geyserRange, Color.green);
            if (Physics.Raycast(ray,geyserRange,playerLayer))
            {
                Debug.DrawRay(ray.origin, ray.direction*geyserRange, Color.red);
                geyserSpawner.isActive = true;
            }
        }
        
    }
}