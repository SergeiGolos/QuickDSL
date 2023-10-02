
namespace Tests
{
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
}