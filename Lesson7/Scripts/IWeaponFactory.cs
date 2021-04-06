using UnityEngine;

namespace Asteroids
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon();
    }
}
