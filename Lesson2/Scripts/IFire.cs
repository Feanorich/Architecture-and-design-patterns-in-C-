namespace Asteroids
{
    public interface IFire
    {
        void Fire(float deltaTime);
        void ClearBullets();
    }
}
