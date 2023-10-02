namespace QuickDSL;

public class AnnotatedXmlAttributes : XmlAttributes
{
    public AnnotatedXmlAttributes(IEnumerable<XmlElementAttribute> list)
    {
        foreach (var element in list)
        {
            this.XmlElements.Add(element);
        }
    }
}