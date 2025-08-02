namespace PatternsTestProject.Patterns.Factory.Abstract
{
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is delicious!");
        }
    }
}