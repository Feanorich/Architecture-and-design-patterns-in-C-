namespace Snake
{
    public interface IMap
    {      
        int SizeX { get; }
        int SizeY { get; }
        void Add(IUnit unit);
        void Remove(IUnit unit);
        bool CheckWallCollision(int x, int y);
        bool CheckUnitCollision(int x, int y, out IUnit unit);
        void ClearMap();
        
    }
}