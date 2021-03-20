using System;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour, ICollision
    {
        public Transform _barrel;

        public event Action<Collision2D> ObjectCollision = delegate (Collision2D ex) { };
        public PlayerController _updater;
        public PlayerData PlayerData;

        private void OnCollisionEnter2D(Collision2D other)
        {
            ObjectCollision.Invoke(other);
        }
    }
}
