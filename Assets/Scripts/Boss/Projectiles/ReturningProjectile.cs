using System.Collections;
using UnityEngine;

namespace Boss.Projectiles
{
    public class ReturningProjectile : Projectile
    {
        private bool _forward;
        private float _stallTime;
        private bool _isNotDestructible;
        protected override void LoadData(ProjectileData projectileData)
        {
            base.LoadData(projectileData);
            var data = (ReturningProjectileData) projectileData;
            _forward = true;
            _stallTime = data.StallTime;
            _isNotDestructible = data.IsNotDestructible;
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

                if(!_isNotDestructible){
                    GetDestroyed();
                }
            }

        }
    }
}