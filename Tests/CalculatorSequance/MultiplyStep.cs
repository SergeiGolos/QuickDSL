namespace Tests.CalculatorSequance
{
    public class MultiplyStep : NumberStep
    {        
        public override int Act(int current, int value)
        {
            return current * value;
        }
    }
}
