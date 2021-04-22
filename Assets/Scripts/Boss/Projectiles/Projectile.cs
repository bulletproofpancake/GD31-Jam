using System;
using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public ProjectileData data;
        private Vector3 _direction;
        private float _damage, _speed, _lifetime;

        private void Start()
        {
            LoadData(data);
            Invoke("GetDestroyed", _lifetime);
        }

        private void LoadData(ProjectileData projectileData)
        {
            _direction = projectileData.SetDirection();
            _damage = projectileData.Damage;
            _speed = projectileData.Speed;
            _lifetime = projectileData.Lifetime;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerAttack>().TakeDamage(_damage);
                GetDestroyed();
            }
        }

        private void GetDestroyed()
        {
            Destroy(gameObject);
        }
    }

}