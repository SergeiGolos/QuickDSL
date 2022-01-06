namespace QuickDSL;

public static class XmlAttributesSyntax { 
    public static XmlAttributes WithElements(this XmlAttributes attributes, IEnumerable<XmlElementAttribute> list) {
        foreach (var element in list)
        {
            attributes.XmlElements.Add(element);
        }
        return attributes;
    }

    }