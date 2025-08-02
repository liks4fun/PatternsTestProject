using NUnit.Framework;
using static System.Console;

namespace PatternsTestProject.Patterns.Singleton.Default
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }
}
