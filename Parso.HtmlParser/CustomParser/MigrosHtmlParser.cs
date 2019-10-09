using Newtonsoft.Json;
using Parso.Common;
using Parso.Common.Base;
using Parso.HtmlParser.CustomEntites;
using Parso.Util;
using ScrapySharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parso.HtmlParser.CustomParser
{
    public class MigrosHtmlParser : HtmlParser, IProductParser<ParsoProduct, ParsoCatalog>
    {
        public MigrosHtmlParser() : base(Common.Enum.ParsoApplicationType.Migros) { }
        public MigrosHtmlParser(string url) : base(url) { }

        public event ParseFinishedEventHandler ParseFinished;
        public List<ParsoProduct> ParseProductList(ParsoCatalog catalog)
        {
            JSONParser<MigrosProduct> migrosProductParser = new JSONParser<MigrosProduct>();
            var listOfProducts = migrosProductParser.ParseDetail(catalog.Url);
            var productList = new List<ParsoProduct>();

            foreach (var product in listOfProducts.aaData)
            {
                if (String.IsNullOrWhiteSpace(product.nm))
                    continue;

                ParsoProduct tmp = new ParsoProduct();

                tmp.ProductId = Convert.ToInt64(product.psi);
                tmp.OldPrice = Convert.ToDecimal(product.mprc);
                tmp.Price = Convert.ToDecimal(product.prc);
                tmp.ProductName = product.nm;
                tmp.PictureUrl = product.img;
                tmp.ProductDetailUrl = product.uri;
                tmp.CatalogId = catalog.Id;

                HDocument workload = GetDocument("https://www.sanalmarket.com.tr" + tmp.ProductDetailUrl);

                tmp.ProductDescription = Parse(workload, @"#groupPromo", false);
                tmp.DiscountDetail = Parse(workload, @"div.udIndirimText", false);

                productList.Add(tmp);

                SaveProduct(tmp);
            }

            ParseFinishedEventArgs e = new ParseFinishedEventArgs(catalog.Id);
            OnParseFinished(e);

            return productList;
        }

        protected virtual void OnParseFinished(ParseFinishedEventArgs e)
        {
            if (ParseFinished != null)
            {
                ParseFinished(this, e);
            }
        }

        public List<ParsoCatalog> ParseCatalogList(long batchId, string rootUrl)
        {
            JSONParser<MigrosCatalog> migrosCatalogParser = new JSONParser<MigrosCatalog>();
            List<MigrosCatalog> migrosCatalogList = migrosCatalogParser.Parse(rootUrl);

            List<ParsoCatalog> catalogList = new List<ParsoCatalog>();

            foreach (var migrosCatalog in migrosCatalogList)
            {
                var catalogDetail = new ParsoCatalog()
                {
                    Name = migrosCatalog.name,
                    RootUrl = rootUrl,
                    Url = "https://www.sanalmarket.com.tr/kweb/getMigroskopDiscountProductList.do?shopCategoryId=" + migrosCatalog.shopCategoryId + @"&sEcho=3&iColumns=13&sColumns=&iDisplayStart=0&iDisplayLength=1000&mDataProp_0=0&mDataProp_1=1&mDataProp_2=2&mDataProp_3=3&mDataProp_4=cat&mDataProp_5=fv&mDataProp_6=mprd&mDataProp_7=cmp&mDataProp_8=mgkp&mDataProp_9=his&mDataProp_10=nm&mDataProp_11=nf&mDataProp_12=prc&sSearch=&bRegex=false&sSearch_0=&bRegex_0=false&bSearchable_0=true&sSearch_1=&bRegex_1=false&bSearchable_1=false&sSearch_2=&bRegex_2=false&bSearchable_2=true&sSearch_3=&bRegex_3=false&bSearchable_3=false&sSearch_4=&bRegex_4=false&bSearchable_4=false&sSearch_5=&bRegex_5=false&bSearchable_5=false&sSearch_6=&bRegex_6=false&bSearchable_6=false&sSearch_7=&bRegex_7=false&bSearchable_7=false&sSearch_8=&bRegex_8=false&bSearchable_8=false&sSearch_9=&bRegex_9=false&bSearchable_9=false&sSearch_10=&bRegex_10=false&bSearchable_10=true&sSearch_11=&bRegex_11=false&bSearchable_11=true&sSearch_12=&bRegex_12=false&bSearchable_12=false&iSortingCols=1&iSortCol_0=0&sSortDir_0=asc&bSortable_0=false&bSortable_1=true&bSortable_2=true&bSortable_3=false&bSortable_4=true&bSortable_5=true&bSortable_6=true&bSortable_7=true&bSortable_8=true&bSortable_9=true&bSortable_10=true&bSortable_11=true&bSortable_12=true",
                    BatchId = batchId
                };

                catalogDetail.Id = SaveCatalog(catalogDetail);
                catalogList.Add(catalogDetail);
            }

            return catalogList;
        }

    }
}
