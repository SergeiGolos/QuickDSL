namespace QuickDSL;

public class ElementBuilder<TOverride> : ElementBuilder
{
    public ElementBuilder(QuickDslBuilder builder) : base(builder, typeof(TOverride))
    {
    }

    public QuickDslBuilder With<TType>(string name)
        where TType : TOverride
    {
        return this.With(name, typeof(TType));
    }
}
public class ElementBuilder {
    protected readonly QuickDslBuilder builder;
    protected readonly Type overrideType;

    public ElementBuilder(QuickDslBuilder builder, Type overrideType)
    {
        this.builder = builder;
        this.overrideType = overrideType;
    }

    public QuickDslBuilder With(string name, Type elementType)
    {
        return this.builder.Add(overrideType, new XmlElementAttribute(name, elementType));        
    }
}