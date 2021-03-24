namespace Asteroids.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {
        protected Weapon _weapon;
        
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon RemoveModification(Weapon weapon);
        
        public void ApplyModification()
        {
            _weapon = AddModification(_weapon);
        }

        public void CancelModification()
        {
            _weapon = RemoveModification(_weapon);
        }

        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
