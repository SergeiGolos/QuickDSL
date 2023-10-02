namespace Prototype.ChainedRequests
{
    public class Manifest
    {
        public string Name { get; set; }

        public Request[] Chain { get; set; }

    }

    public abstract class Request
    {
        public abstract IObservable<(string, string)> Process(Dictionary<string, string> context);
    }
}