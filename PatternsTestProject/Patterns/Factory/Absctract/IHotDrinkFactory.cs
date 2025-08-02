namespace PatternsTestProject.Patterns.Factory.Abstract
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}