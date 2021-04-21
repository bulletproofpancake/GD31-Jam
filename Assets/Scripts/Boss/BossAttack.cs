using System;
using Boss.Projectiles;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner harpoonSpawner, geyserSpawner;
    [SerializeField] private float harpoonRange, geyserRange;
}
