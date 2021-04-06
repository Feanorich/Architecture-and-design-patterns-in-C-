using System;

namespace Asteroids
{
    public interface IDestroyMessage
    {
        void UnitDestroyed(IUpdate unit);
        void AddUnit(IUpdate unit);        
    }
}
