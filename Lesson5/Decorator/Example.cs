using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")] 
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        private bool _setMuffler = false;
        private bool _setSight = false;

        ModificationWeapon modificationWeapon;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);

            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPositionMuffler, _muffler);
            
            modificationWeapon = 
                new ModificationMuffler(weapon, _audioSource, muffler, _barrelPositionMuffler.position,
                _audioClip, _barrelPosition);
            modificationWeapon.ApplyModification();
            _setMuffler = true;

            _fire = modificationWeapon;

            
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                if (_setMuffler)
                {
                    modificationWeapon.CancelModification();
                    _setMuffler = false;
                }
                else
                {
                    modificationWeapon.ApplyModification();
                    _setMuffler = true;
                }

            }
        }
    }
}
