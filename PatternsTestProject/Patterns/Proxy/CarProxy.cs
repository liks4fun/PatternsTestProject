namespace PatternsTestProject.Patterns.Proxy
{
    public class CarProxy : ICar
    {
        private Car car = new Car();
        private Driver driver;

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 16)
                car.Drive();
            else
            {
                Console.WriteLine("Driver too young");
            }
        }
    }
}