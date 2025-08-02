namespace PatternsTestProject.Patterns.State
{
    public static class PhoneRules
    {
        public static Dictionary<State, List<(Trigger, State)>> rules
      = new Dictionary<State, List<(Trigger, State)>>
      {
          [State.OffHook] = new List<(Trigger, State)>
        {
          (Trigger.CallDialed, State.Connecting)
        },
          [State.Connecting] = new List<(Trigger, State)>
        {
          (Trigger.HungUp, State.OffHook),
          (Trigger.CallConnected, State.Connected)
        },
          [State.Connected] = new List<(Trigger, State)>
        {
          (Trigger.LeftMessage, State.OffHook),
          (Trigger.HungUp, State.OffHook),
          (Trigger.PlacedOnHold, State.OnHold)
        },
          [State.OnHold] = new List<(Trigger, State)>
        {
          (Trigger.TakenOffHold, State.Connected),
          (Trigger.HungUp, State.OffHook)
        }
      };
    }
}