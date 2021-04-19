using System.Collections;
using UnityEngine;

namespace Boss
{
    public class ReturningProjectile : Projectile
    {
        private bool _forward;

        protected override void LoadData(ProjectileData projectileData)
        {
            base.LoadData(projectileData);
            _forward = true;
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
                yield return new WaitForSeconds(lifetime/2);
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