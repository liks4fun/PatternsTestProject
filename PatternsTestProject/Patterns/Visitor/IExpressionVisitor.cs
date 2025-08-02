namespace PatternsTestProject.Patterns.Visitor
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionExpression ae);
    }
}