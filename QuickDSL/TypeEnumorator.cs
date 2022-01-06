namespace QuickDSL;

public class TypeEnumorator<TType> : List<Type>
{
    public TypeEnumorator()
    {
        this.Add(typeof(TType));
        this.Parse(typeof(TType));
    }

    private void Parse(Type type) 
    {
        var result = type.GetProperties()
            .Select(p => p.PropertyType.IsArray ? p.PropertyType.GetElementType() : p.PropertyType)
            .Where(t => !this.Contains(t));

        if (!result.Any())
        {
            return;
        }

        foreach (var t in result)
        {
            this.Add(t);
            this.Parse(t);
        }
    }
}
