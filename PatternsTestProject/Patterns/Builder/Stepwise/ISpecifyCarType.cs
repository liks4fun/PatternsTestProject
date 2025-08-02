namespace PatternsTestProject.Patterns.Builder.Stepwise
{
    public interface ISpecifyCarType
    {
        public ISpecifyWheelSize OfType(CarType type);
    }
}