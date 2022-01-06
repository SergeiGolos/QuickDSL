namespace QuickDSL;

public class ElementBuilder<TOverride>
{
    private readonly QuickDslBuilder builder;

    public ElementBuilder(QuickDslBuilder builder)
    {
        this.builder = builder;
    }

    public QuickDslBuilder With<TType>(string name)
        where TType : TOverride
    {
        return this.builder.Add<TOverride>(new XmlElementAttribute(name, typeof(TType)));        
    }
}