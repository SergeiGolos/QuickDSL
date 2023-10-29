
using QuickDSL.Sequence;
using Tests.CalculatorSequance;

namespace Tests;

public class CalculatorSequenceTests
{
    private QuickDslSerializer<SimpleCalculator> serializer;

    public CalculatorSequenceTests()
    {
        this.serializer = new QuickDslBuilder()
            .Override<SimpleStep>().With<AddStep>("add")
            .Override<SimpleStep>().With<SubStep>("sub")
            .Override<SimpleStep>().With<MultiplyStep>("multiply")
            .Override<SimpleStep>().With<DivideStep>("divide")
            .Build<SimpleCalculator>();
    }

    [Fact]
    public void AddSingleNumber()
    {
        var example = @"<SimpleCalculator>
                            <add>2</add>
                        </SimpleCalculator>";
      
        var calculator = serializer.Deserialize(example);      
        var result = calculator.Execute();

        Assert.Equal(2, result["value"]);
    }

    [Fact]
    public void AddTwoNumber()
    {
        var example = @"<SimpleCalculator>
                            <add>2</add>
                            <add>2</add>
                        </SimpleCalculator>";

        var calculator = serializer.Deserialize(example);
        var result = calculator.Execute();

        Assert.Equal(4, result["value"]);
    }

    [Fact]
    public void AddTwoNumberAndSubtract()
    {
        var example = @"<SimpleCalculator>
                            <add>2</add>
                            <add>2</add>
                            <sub>5</sub>
                        </SimpleCalculator>";

        var calculator = serializer.Deserialize(example);
        var result = calculator.Execute();

        Assert.Equal(-1, result["value"]);
    }
}
