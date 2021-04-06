using System;
using UnityEngine;

namespace Asteroids
{
    public interface ICollision
    {
        event Action<Collision2D> ObjectCollision;
    }
}
