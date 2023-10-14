using System.Dynamic;

namespace QuickDSL.Sequence;

public class SimpleContext : Dictionary<string, object> 
{
    public SimpleContext Set<TType>(string key, TType value)
    {
        if (!this.ContainsKey(key))
        {
            this.Add(key, value);
        }
        else
        {
            this[key] = value;
        }
        return this;
    }

    public SimpleContext Set(string key, object value)
    {
        if (!this.ContainsKey(key))
        {
            this.Add(key, value);
        }
        else
        {
            this[key] = value;
        }
        return this;
    }
    
    public SimpleContext AddRange(IEnumerable<(string key, object value)> items) 
    {
        foreach (var item in items)
        {
            this.Set(item.key, item.value);
        }
        return this;
    }

    public TType? Get<TType>(string key)
    {
        if (this.ContainsKey(key)) 
        { 
            return (TType)this[key]; 
        }
        
        return default;
    }
}
