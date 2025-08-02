namespace PatternsTestProject.Patterns.Visitor
{
    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }
}