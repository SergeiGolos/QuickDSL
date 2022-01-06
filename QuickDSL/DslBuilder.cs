using System.Linq;

namespace QuickDSL;

public class DslPropertyBuilder<TOverride>
{
    private readonly DslBuilder builder;

    public DslPropertyBuilder(DslBuilder builder)
    {
        this.builder = builder;
    }

    public DslBuilder With<TType>(string name)
    {
        this.builder.Add(new XmlAttributeOverrideLink<TOverride>(name, typeof(TType)));
        return this.builder;
    }
}

public class DslBuilder
{
    public List<XmlAttributeOverrideLink> dslTypes = new List<XmlAttributeOverrideLink>();
    
    public DslBuilder Add(XmlAttributeOverrideLink link)
    {
        this.dslTypes.Add(link);
        return this;
    }
    
    public DslPropertyBuilder<TOverride> Override<TOverride>()
    {                
        return new DslPropertyBuilder<TOverride>(this);
    }

    public XmlAttributeOverrides Build(params Type[] serializable) 
    {
        var overrides = new XmlAttributeOverrides();
        var groups = dslTypes
            .GroupBy(n => n.OverrideType, n => n.Attribute)
            .ToDictionary(x=>x.Key, x=>(IEnumerable<XmlElementAttribute>)x);
        

        foreach (var type in serializable)
        {
            var properties = type.GetProperties()
                .Where(t => t.PropertyType.IsArray)
                .Select(t=> (Property: t, Type: t.PropertyType.GetElementType()))
                .Where(t => groups.ContainsKey(t.Type));

            foreach (var property in properties) 
            {
                var attributes = new XmlAttributes();
                foreach (var element in groups[property.Type])
                {                    
                    attributes.XmlElements.Add(element);                    
                }
                overrides.Add(type, property.Property.Name, attributes);
            }
        }
        return overrides;
    }
}
