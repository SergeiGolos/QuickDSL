using QuickDSL;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {        
        [Fact]
        public void Test1()
        {
            var example = "<RootClass><a></a><b></b></RootClass>";
            
            var xmlOverrides = new QuickDslBuilder()
                .Override<BaseClass>().With<ClassA>("a")
                .Override<BaseClass>().With<ClassB>("b")
                .Build(typeof(RootClass));
            
            var serializer = new XmlSerializer(typeof(RootClass), xmlOverrides);
            
            using TextReader reader = new StringReader(example);
            var result = (RootClass)serializer.Deserialize(reader);
            
            Assert.NotEmpty(result.Values);
            Assert.Equal(typeof(ClassA), result.Values.First().GetType());
            Assert.Equal(typeof(ClassB), result.Values.Last().GetType());
        }
    }

    public class RootClass
    {
        public BaseClass[] Values { get; set; }
    }

    public class BaseClass
    {        
    }
    public class ClassA : BaseClass
    {

    }

    public class ClassB : BaseClass
    {
    }
}