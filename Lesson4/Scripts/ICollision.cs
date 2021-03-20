using System;
using UnityEngine;

namespace Asteroids
{
    interface ICollision
    {
        event Action<Collision2D> ObjectCollision;
    }
}
