using UnityEngine;

namespace Asteroids
{
    public class CanonFactory : IWeaponFactory
    {
        private GameObject _bullet;
        private Transform  _barrel;
        private float      _force;
        private float      _lifeTime;
        
        public CanonFactory(GameObject bullet, Transform barrel, 
            float force, float lifeTime)
        {
            _bullet   = bullet;
            _barrel   = barrel;
            _force    = force;
            _lifeTime = lifeTime;
        }

        public IWeapon CreateWeapon()
        {
            IWeapon _result;
            Rigidbody2D _rigidbody2D = _bullet.GetOrAddComponent<Rigidbody2D>();
            _result = new Canon(_rigidbody2D, _barrel, _force, _lifeTime);

            return _result;
        }
    }
}
