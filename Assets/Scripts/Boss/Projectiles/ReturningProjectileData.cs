using UnityEngine;

namespace Boss.Projectiles
{
    [CreateAssetMenu(menuName = "Data/Boss/Projectiles/ReturningProjectileData")]
    public class ReturningProjectileData : ProjectileData
    {
        [SerializeField] private float stallTime;
        public float StallTime => stallTime;
        [SerializeField] private bool isNotDestructible;
        public bool IsNotDestructible => isNotDestructible;
    }
}