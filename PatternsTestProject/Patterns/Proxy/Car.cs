namespace PatternsTestProject.Patterns.Proxy
{
    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car being driven");
        }
    }
}