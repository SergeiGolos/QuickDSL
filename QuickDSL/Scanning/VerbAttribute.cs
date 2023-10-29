using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDSL.Scanning
{
    [AttributeUsage(AttributeTargets.Class)]
    public class VerbAttribute : Attribute
    {
        public VerbAttribute(string verb)
        {
            Name = verb;
        }

        public string Name { get;set; }
    }
}
