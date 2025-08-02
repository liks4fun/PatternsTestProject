namespace PatternsTestProject.Patterns.Builder.Stepwise
{
    public interface ISpecifyWheelSize
    {
        public IBuildCar WithWheels(int size);
    }
}