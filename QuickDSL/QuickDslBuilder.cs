using System.Collections;

namespace QuickDSL;

public class QuickDslBuilder
{
    public List<(Type, XmlElementAttribute)> dslTypes = new List<(Type, XmlElementAttribute)>();

    public QuickDslBuilder Add<TOverride>(XmlElementAttribute attribute)
    {
        this.dslTypes.Add((typeof(TOverride), attribute));
        return this;
    }

    public ElementBuilder<TOverride> Override<TOverride>()
    {
        return new ElementBuilder<TOverride>(this);
    }
    
    public QuickDslSerializer<TType> Build<TType>()
    {        
        var overrides = new XmlAttributeOverrides();
        var groups = dslTypes
            .GroupBy(n => n.Item1, n => n.Item2)
            .ToDictionary(x => x.Key, x => (IEnumerable<XmlElementAttribute>)x);

        var typeEnumerator = new TypeEnumerator<TType>();
        foreach (var type in typeEnumerator)
        {
            var properties = type.GetProperties()
                .Where(t => t.PropertyType.IsArray)
                .Select(t => (Property: t, Type: t.PropertyType.GetElementType()))
                .Where(t => groups.ContainsKey(t.Type));

            foreach (var property in properties)
            {
                var attributes = new AnnotatedXmlAttributes(groups[key: property.Type]);
                overrides.Add(type, property.Property.Name, attributes);
            }
        }
        return new QuickDslSerializer<TType>(overrides);
    }
}
