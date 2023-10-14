
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
        var example = "<SimpleCalculator><add>2</add></SimpleCalculator>";
      
        var calculator = serializer.Deserialize(example);      
        var result = calculator.Execute();

        Assert.Equal(2, result["value"]);
    }

    [Fact]
    public void AddTwoNumber()
    {
        var example = "<SimpleCalculator><add>2</add><add>2</add></SimpleCalculator>";

        var calculator = serializer.Deserialize(example);
        var result = calculator.Execute();

        Assert.Equal(4, result["value"]);
    }

}

public class TypeEnumeratorTests
{
    [Fact]
    public void I_should_get_more_types()
    {
        var result = new TypeEnumerator<RootClass>();

        Assert.Equal(2, result.Count());
    }

    public class RootClass
    {
        public BaseClass[] Values { get; set; }
    }

    public class BaseClass
    {
        public BaseClass[] Values { get; set; }
    }
}

public class DslBuilderTests
{        
    [Fact]
    public void Loading_a_single_override_at_the_root_level()
    {
        var example = "<RootClass><a></a><b></b></RootClass>";
        
        var serializer = new QuickDslBuilder()
            .Override<BaseClass>().With<ClassA>("a")
            .Override<BaseClass>().With<ClassB>("b")
            .Build<RootClass>();

        var result = serializer.Deserialize(example);

        Assert.NotEmpty(result.Values);
        Assert.Equal(typeof(ClassA), result.Values.First().GetType());           
        Assert.Equal(typeof(ClassB), result.Values.Last().GetType());
    }

    [Fact]
    public void Loading_a_single_override_at_the_nested_level()
    {
        var example = "<RootClass><a><a></a></a><b><a></a></b></RootClass>";

        var serializer = new QuickDslBuilder()
            .Override<BaseClass>().With<ClassA>("a")
            .Override<BaseClass>().With<ClassB>("b")
            .Build<RootClass>();

        var result = serializer.Deserialize(example);

        Assert.NotEmpty(result.Values);
        Assert.Equal(typeof(ClassA), result.Values.First().GetType());
        Assert.Equal(typeof(ClassA), result.Values.First().Values.First().GetType());
        Assert.Equal(typeof(ClassB), result.Values.Last().GetType());
    }


    public class RootClass
    {
        public BaseClass[] Values { get; set; }
    }

    public class BaseClass
    {
        public BaseClass[] Values { get; set; }
    }
    public class ClassA : BaseClass
    {
    }

    public class ClassB : BaseClass
    {
    }
}    