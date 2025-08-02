public class NoBonusesModifier : CreatureModifier
{
    public NoBonusesModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
        // nothing
        Console.WriteLine("No bonuses for you!");
    }
}