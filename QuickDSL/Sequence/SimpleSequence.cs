
namespace QuickDSL.Sequence;

public interface ISimpleSequence
{
    SimpleStep[] Steps { get; set; }

    Dictionary<string, object> Execute();    
}