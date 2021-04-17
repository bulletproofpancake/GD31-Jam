using System;
using System.Collections;
using UnityEngine;

namespace Boss
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Direction _direction;
        private Vector3 dir;
        
        private void Start()
        {
            dir = SetDirection();
            StartCoroutine(Move(dir));
        }

        Vector3 SetDirection()
        {
            switch (_direction)
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
        
        IEnumerator Move(Vector3 direction)
        {
            var timer = 2.0f;
            while (timer > 0)
            {
                transform.position += direction * (Time.deltaTime * 2);
                yield return new WaitForEndOfFrame();
                timer -= Time.deltaTime;
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