namespace QuickDSL;

public class AttributeMap<TType> : AttributeMap
{    
    public AttributeMap(string? elementName, Type? type) 
    {
        this.Attribute = new XmlElementAttribute(elementName, type);
        this.OverrideType = typeof(TType);
    }
}
