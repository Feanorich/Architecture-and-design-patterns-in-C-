namespace Snake
{
    public interface IFoodFactory
    {       
        IUnit RandomFood();
        IUnit StartFood();
        void DestroyFood(IUnit food);
    }
}