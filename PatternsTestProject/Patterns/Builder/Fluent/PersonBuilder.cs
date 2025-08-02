namespace PatternsTestProject.Patterns.Builder.Fluent
{
    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }
}