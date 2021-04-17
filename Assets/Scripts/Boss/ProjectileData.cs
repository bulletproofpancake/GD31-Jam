using System;
using UnityEngine;

namespace Boss
{
    [CreateAssetMenu(menuName = "Data/Boss/ProjectileData")]
    public class ProjectileData : ScriptableObject
    {

        [SerializeField] private Direction direction;
        public float damage, speed, lifetime;

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