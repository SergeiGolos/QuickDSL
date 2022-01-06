namespace QuickDSL;

public class QuickDslBuilder
{
    public List<AttributeMap> dslTypes = new List<AttributeMap>();

    public QuickDslBuilder Add(AttributeMap link)
    {
        this.dslTypes.Add(link);
        return this;
    }

    public ElementBuilder<TOverride> Override<TOverride>()
    {
        return new ElementBuilder<TOverride>(this);
    }
    
    public QuickDslSerializer<TType> Build<TType>()
    {
        Type type = typeof(TType);
        var overrides = new XmlAttributeOverrides();
        var groups = dslTypes
            .GroupBy(n => n.OverrideType, n => n.Attribute)
            .ToDictionary(x => x.Key, x => (IEnumerable<XmlElementAttribute>)x);

        var properties = type.GetProperties()
            .Where(t => t.PropertyType.IsArray)
            .Select(t => (Property: t, Type: t.PropertyType.GetElementType()))
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

        return new QuickDslSerializer<TType>(overrides);
    }
}