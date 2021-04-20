using System.Collections;
using UnityEngine;

namespace Boss
{
    public class ReturningProjectile : Projectile
    {
        private bool _forward;
        private float _stallTime;
        protected override void LoadData(ProjectileData projectileData)
        {
            base.LoadData(projectileData);
            var data = (ReturningProjectileData) projectileData;
            _forward = true;
            _stallTime = data.StallTime;
        }

        protected override IEnumerator Move(Vector3 direction, float lifetime, float speed)
        {
            var timer = lifetime;
            print(_forward);
            if (_forward)
            {
                while (timer > 0)
                {
                    transform.position += direction * (Time.deltaTime * speed);
                    yield return new WaitForEndOfFrame();
                    timer -= Time.deltaTime;
                }

                _forward = false;
                StartCoroutine(Move(direction, lifetime, speed));
            }
            else
            {
                yield return new WaitForSeconds(_stallTime);
                while (timer > 0)
                {
                    transform.position += -direction * (Time.deltaTime * speed);
                    yield return new WaitForEndOfFrame();
                    timer -= Time.deltaTime;
                }
                Destroy(gameObject);
            }

        }
    }
}