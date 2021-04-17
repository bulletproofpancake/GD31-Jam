using System;
using System.Collections;
using UnityEngine;

namespace Boss
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData data;
        private Vector3 _direction;
        private float _damage, _speed, _lifetime;

        private void Start()
        {
            LoadData(data);
            StartCoroutine(Move(_direction, _lifetime));
        }

        private void LoadData(ProjectileData projectileData)
        {
            _direction = projectileData.SetDirection();
            _damage = projectileData.damage;
            _speed = projectileData.speed;
            _lifetime = projectileData.lifetime;
        }
        
        private IEnumerator Move(Vector3 direction, float lifetime)
        {
            var timer = lifetime;
            print(timer);
            while (timer > 0)
            {
                transform.position += direction * (Time.deltaTime * _speed);
                yield return new WaitForEndOfFrame();
                print($"{timer:0}");
                timer -= Time.deltaTime;
            }
        }

        public void GiveDamage(float hp)
        {
            hp -= _damage;
        }
    }

}