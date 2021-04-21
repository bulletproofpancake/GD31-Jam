﻿using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData data;
        private Vector3 _direction;
        private float _damage, _speed, _lifetime;
        private Rigidbody _rigidbody;
        private bool _isActive;
        
        public float Damage => _damage;

        private void Start()
        {
            LoadData(data);
            StartMoving(_direction, _lifetime, _speed);
        }

        protected void StartMoving(Vector3 direction, float lifetime, float speed)
        {
            StartCoroutine(Move(direction, lifetime, speed));
        }

        #region MoveRigidbody

        // private void Update()
        // {
        //     if (_lifetime > 0)
        //     {
        //         _isActive = true;
        //         _lifetime -= Time.deltaTime;
        //     }
        //     else
        //     {
        //         _isActive = false;
        //         Destroy(gameObject);
        //     }
        // }
        //
        // private void FixedUpdate()
        // {
        //     if (_isActive)
        //     {
        //         Move(_direction);
        //     }
        // }
        //
        // private void Move(Vector3 direction)
        // {
        //     _rigidbody.MovePosition(_rigidbody.position + direction * (_speed * Time.fixedDeltaTime));
        // }

        #endregion
        
        #region MoveCoroutine

        protected virtual IEnumerator Move(Vector3 direction, float lifetime, float speed)
        {
            var timer = lifetime;
            while (timer > 0)
            {
                transform.position += direction * (Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
                timer -= Time.deltaTime;
            }

            GetDestroyed();
        }

        #endregion
        
        protected virtual void LoadData(ProjectileData projectileData)
        {
            _direction = projectileData.SetDirection();
            _damage = projectileData.Damage;
            _speed = projectileData.Speed;
            _lifetime = projectileData.Lifetime;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void GetDestroyed()
        {
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GetDestroyed();
            }
        }
    }

}