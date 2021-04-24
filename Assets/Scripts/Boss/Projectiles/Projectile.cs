using System;
using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public ProjectileData data;
        protected Vector3 _direction;
        protected float _damage, _speed, _lifetime;

        protected virtual void Start()
        {
            LoadData(data);
            Invoke("GetDestroyed", _lifetime);
        }

        protected void LoadData(ProjectileData projectileData)
        {
            _direction = projectileData.SetDirection();
            _damage = projectileData.Damage;
            _speed = projectileData.Speed;
            _lifetime = projectileData.Lifetime;
        }

        protected virtual void Update()
        {
            Move();
        }

        protected void Move()
        {
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerAttack>().TakeDamage(_damage);
                GetDestroyed();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerAttack>().TakeDamage(_damage);
                GetDestroyed();
            }
        }

        protected virtual void GetDestroyed()
        {
            Destroy(gameObject);
        }
    }

}