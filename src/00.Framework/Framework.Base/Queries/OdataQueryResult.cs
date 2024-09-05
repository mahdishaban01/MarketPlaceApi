namespace Framework.Base.Queries;

public class QueryResult<T>(T dataResult, object countResult)
{
    public T DataResult { get; } = dataResult;
    public object CountResult { get; } = countResult;
}