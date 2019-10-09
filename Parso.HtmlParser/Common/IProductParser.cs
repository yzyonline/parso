using System.Collections.Generic;

namespace Parso.HtmlParser
{
    public interface IProductParser<T,Y>
    {
        List<T> ParseProductList(Y catalog);
        List<Y> ParseCatalogList(long batchId,string rootUrl);
    }
}
