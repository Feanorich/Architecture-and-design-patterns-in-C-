using System;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour, IUnitView
    {
        public Transform _barrel;

        public event Action<Collision2D> ObjectCollision = delegate (Collision2D ex) { };
        public PlayerData PlayerData;

        public IUnit Unit { get; set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            ObjectCollision.Invoke(other);
        }
    }
}
