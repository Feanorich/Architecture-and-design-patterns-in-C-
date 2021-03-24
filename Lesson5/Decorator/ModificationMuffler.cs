using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private GameObject _mufflerObject;

        private readonly AudioClip _startAudioClip;
        private readonly Transform  _startBarrelPosition;
        private readonly float _startVolume;

        public ModificationMuffler(Weapon weapon, AudioSource audioSource, IMuffler muffler, 
            Vector3 mufflerPosition, AudioClip startAudioSource, Transform startBarrelPosition)
        {
            _weapon = weapon;

            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;

            _startAudioClip = startAudioSource;
            _startBarrelPosition = startBarrelPosition;
            _startVolume = _audioSource.volume;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerObject = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            _audioSource.volume = _startVolume;
            GameObject.Destroy(_mufflerObject);
            weapon.SetAudioClip(_startAudioClip);
            weapon.SetBarrelPosition(_startBarrelPosition);
            return weapon;
        }
    }
}
