namespace QuickDSL;

public class ElementBuilder<TOverride>
{
    private readonly QuickDslBuilder builder;

    public ElementBuilder(QuickDslBuilder builder)
    {
        this.builder = builder;
    }

    public QuickDslBuilder With<TType>(string name)
    {
        this.builder.Add(new AttributeMap<TOverride>(name, typeof(TType)));
        return this.builder;
    }
}
