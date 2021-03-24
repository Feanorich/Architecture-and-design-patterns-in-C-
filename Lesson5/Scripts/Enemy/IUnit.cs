using System;
using UnityEngine;

namespace Asteroids
{
    public interface IUnit : IUpdate, IHealth, ICollisionReceiver
    {

    }
}
