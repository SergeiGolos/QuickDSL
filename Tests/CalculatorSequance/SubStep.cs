namespace Tests.CalculatorSequance
{
    public class SubStep : NumberStep
    {
        public override int Act(int current, int value)
        {
            return current - value;
        }
    }
}
