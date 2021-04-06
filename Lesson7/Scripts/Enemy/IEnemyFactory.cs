using System;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemyUnit(Vector3 enemyPosition, Quaternion enemyRotation, float startSpeed);
    }
}
