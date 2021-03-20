using System;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour, ICollision
    {
        public event Action<Collision2D> ObjectCollision = delegate (Collision2D ex) { };
        public BulletController _updater;

        private void OnCollisionEnter2D(Collision2D other)
        {
            ObjectCollision.Invoke(other);
        }
    }
}
