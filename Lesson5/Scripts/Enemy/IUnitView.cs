namespace Asteroids
{
    public interface IUnitView : ICollision
    {
        IUnit Unit { get; set; }
    }
}
