using System.Text;

namespace PatternsTestProject.Patterns.Strategy
{
    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }
}