using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuickDSL.Scanning
{
    public class AnchorProperty
    {
        private readonly PropertyInfo property;
        private readonly Type anchor;

        public AnchorProperty(PropertyInfo info, Type anchor)
        {
            this.property = info;
            this.anchor = anchor;
        }

        public string Name
            => this.property.Name;

        public Type? ReflectedType
            => this.property.ReflectedType;

        public Type? AnchoredType
            => anchor;

        public AnchorAttribute[] GetAnchors()
            => this.property
                .GetCustomAttributes<AnchorAttribute>()
                .ToArray();
    }

    //public class DslScanner
    //{
    //    public (Type, PropertyInfo, AnchorAttribute)
    //}

    public class QuickDslBuilder<TRuntime> : QuickDslBuilder
    {
        private readonly IEnumerable<(Type, VerbAttribute[])> verbs;
        private readonly IEnumerable<(Type, DslAttribute[])> runtimes;

        public QuickDslBuilder(Assembly assembly)
        {
            var scanner = new Scanner(assembly);
            this.verbs = scanner.Scan<VerbAttribute>();

            this.runtimes = scanner.Scan<DslAttribute>();

            foreach (var (runtime, _) in this.runtimes)
            {
                var anchors = runtime.GetProperties()
                    .Select(n => (n, n.GetCustomAttribute<AnchorAttribute>()))
                    .Where(n => n.Item2 != null);

                foreach (var (anchor, _) in anchors)
                {


                }
            }
        }
    }

    internal class Scanner
    {
        private readonly Assembly assembly;

        public Scanner(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IEnumerable<(Type, TType[])> Scan<TType>()
            where TType : Attribute
        {
            return this.assembly.GetTypes()
                .Select(n => (n, (TType[])n.GetCustomAttributes(typeof(TType), true)))
                .Where(n => n.Item2.Length > 0);
        }
    }
}
