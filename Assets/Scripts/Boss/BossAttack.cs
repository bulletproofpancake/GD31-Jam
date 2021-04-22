using System;
using Boss.Projectiles;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner harpoonSpawner, geyserSpawner;
    [SerializeField] private float harpoonRange, geyserRange;
    [SerializeField] private Transform eyes;
    [SerializeField] private LayerMask playerMask;

    private void Update()
    {
        AttackPlayer();
    }

    void AttackPlayer()
    {
        var ray = new Ray(eyes.position, Vector3.left);
        Debug.DrawRay(ray.origin, ray.direction * harpoonRange, Color.green);

        if (!Physics.SphereCast(ray,1f,out var hit,harpoonRange,playerMask)) return;
        if (!hit.collider.CompareTag("Player")) return;
        
        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        harpoonSpawner.StartSpawning();

        if (hit.point.x <= geyserRange)
        {
            print("geyser");
            geyserSpawner.StartSpawning();
        }
        
    }

}
