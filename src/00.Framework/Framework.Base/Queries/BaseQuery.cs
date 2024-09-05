namespace Framework.Base.Queries;

public class BaseQuery
{
    public required GetOdataQuery Data { get; set; }
    public required GetOdataQuery Count { get; set; }
}
