namespace Tests.CalculatorSequance
{
    public class AddStep : NumberStep
    {
        public override int Act(int current, int value)
        {
            return current + value;
        }
    }
}
