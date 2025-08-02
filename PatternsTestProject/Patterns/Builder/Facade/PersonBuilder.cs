namespace PatternsTestProject.Patterns.Builder.Facade
{
    public class PersonBuilder
    {
        protected Person person = new Person();

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }
}