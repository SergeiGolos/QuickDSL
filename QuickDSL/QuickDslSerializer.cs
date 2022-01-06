using System.Text;

namespace QuickDSL;

public class QuickDslSerializer<TType>
{    
    private XmlSerializer xmlSerializer;

    public QuickDslSerializer(XmlAttributeOverrides overrides)
    {
        this.xmlSerializer = new XmlSerializer(typeof(TType), overrides);
    }

    public TType Deserialize(string value)
    {
        using TextReader reader = new StringReader(value);
        return (TType)this.xmlSerializer.Deserialize(reader);
    }

    public string Serialize(TType root)
    {
        var sb = new StringBuilder();
        using (TextWriter writer = new StringWriter(sb))
        {
            xmlSerializer.Serialize(writer, root);
        }

        return sb.ToString();        
    }
}
