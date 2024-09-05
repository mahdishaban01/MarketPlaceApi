namespace Framework.Base.Queries;

public class GetOdataQuery
{
    public GetOdataQuery((string, IDictionary<string, object>) odataQuery)
    {
        var (item1, dictionary) = odataQuery;
        Query = item1;
        Parameters = dictionary;
    }
    public string Query { get; }
    public IDictionary<string, object> Parameters { get; }
}