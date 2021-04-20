using UnityEngine;

namespace Boss
{
    [CreateAssetMenu(menuName = "Data/Boss/Projectiles/ReturningProjectileData")]
    public class ReturningProjectileData : ProjectileData
    {
        [SerializeField] private float stallTime;
        public float StallTime => stallTime;
    }
}