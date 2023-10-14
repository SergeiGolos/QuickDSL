namespace QuickDSL.Sequence;

public class SimpleContext : Dictionary<string, object> 
{
    public void AddRange(IEnumerable<(string key, object value)> items) 
    {
        foreach (var item in items)
        {
            if (!this.ContainsKey(item.key))
            {
                this.Add(item.key, item.value);
            }
            else
            {
                this[item.key] = item.value; 
            }
        }
    }
}
