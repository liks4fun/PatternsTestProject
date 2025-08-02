namespace PatternsTestProject.Patterns.Proxy
{
    public class Driver
    {
        public int Age { get; set; }
        private readonly int age;
        public Driver(int age)
        {
            this.age = age;
            
        }
    }
}