namespace QuickDSL;

public class XmlAttributeOverrideLink<TType> : XmlAttributeOverrideLink
{    
    public XmlAttributeOverrideLink(string? elementName, Type? type) 
    {
        this.Attribute = new XmlElementAttribute(elementName, type);
        this.OverrideType = typeof(TType);
    }
}
