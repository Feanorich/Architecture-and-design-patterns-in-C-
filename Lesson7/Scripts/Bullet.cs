using System;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour, IUnitView
    {
        public event Action<Collision2D> ObjectCollision = delegate (Collision2D ex) { };        

        public IUnit Unit { get; set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            ObjectCollision.Invoke(other);
        }
    }
}
