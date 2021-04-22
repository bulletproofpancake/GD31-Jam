using System;
using UnityEngine;

namespace Boss.Projectiles
{
    public class BossAttack : MonoBehaviour
    {
        [SerializeField] private Transform eyes;
        [SerializeField] private ProjectileSpawner harpoonSpawner,geyserSpawner;
        [SerializeField] private float harpoonRange,geyserRange;
        [SerializeField] private LayerMask playerLayer;
        
        private void Update()
        {
            ShootHarpoon();
        }

        void ShootHarpoon()
        {
            var ray = new Ray(eyes.position, Vector3.left);
            Debug.DrawRay(ray.origin, ray.direction*harpoonRange, Color.green);
            if (Physics.Raycast(ray,harpoonRange,playerLayer))
            {
                Debug.DrawRay(ray.origin, ray.direction*harpoonRange, Color.red);
                harpoonSpawner.isActive = true;
            }
        }
    }
}