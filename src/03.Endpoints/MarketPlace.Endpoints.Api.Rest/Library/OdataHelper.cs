using DynamicODataToSQL;
using Microsoft.AspNetCore.WebUtilities;
using SqlKata.Compilers;

namespace MarketPlace.Endpoints.Api.Rest.Library;

public class OdataHelper
{
    public static Dictionary<string, string> GetOdataDictionary(string select, string filter, string orderby,
        string apply, int top, int skip)
    {
        var dic = new Dictionary<string, string>
        {
            {"select", select},
            {"filter", filter},
            {"orderby", orderby},
            {"top", (top).ToString()},
            {"skip", skip.ToString()},
            {"apply", apply}
        };
        return dic;
    }

    public static readonly ODataToSqlConverter Converter = new(new EdmModelBuilder(), new SqlServerCompiler { UseLegacyPagination = false });

    public static void AddQueryString(ref string uri, string name, string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return;
        uri = QueryHelpers.AddQueryString(uri, name, value);
    }

    public static string GetNextLink(HttpRequest httpRequest, string select, string filter, string orderby,
        string apply, int top, int skip)
    {
        var nextLink = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.Path}";
        AddQueryString(ref nextLink, "$select", select);
        AddQueryString(ref nextLink, "$filter", filter);
        AddQueryString(ref nextLink, "$orderBy", orderby);
        AddQueryString(ref nextLink, "$top", top.ToString());
        AddQueryString(ref nextLink, "$skip", (skip + top).ToString());
        AddQueryString(ref nextLink, "$apply", apply);
        return nextLink;
    }
}
