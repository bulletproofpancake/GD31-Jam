using System;
using Boss.Projectiles;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner harpoonSpawner, geyserSpawner;

    private void Start()
    {
        harpoonSpawner.StartSpawning();
    }
}
