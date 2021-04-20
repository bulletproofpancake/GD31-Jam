using System;
using UnityEngine;

namespace Boss
{
    [CreateAssetMenu(menuName = "Data/Boss/Projectiles/ProjectileData")]
    public class ProjectileData : ScriptableObject
    {

        [SerializeField] protected Direction direction;
        [SerializeField] protected float damage, speed, lifetime;
        public float Damage => damage;
        public float Speed => speed;
        public float Lifetime => lifetime;

        public Vector3 SetDirection()
        {
            switch (direction)
            {
                case Direction.Up:
                    return Vector3.up;
                case Direction.Down:
                    return Vector3.down;
                case Direction.Left:
                    return Vector3.left;
                case Direction.Right:
                    return Vector3.right;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}