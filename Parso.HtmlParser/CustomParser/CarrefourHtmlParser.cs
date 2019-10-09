using HtmlAgilityPack;
using Parso.Common;
using Parso.Common.Base;
using Parso.Entities;
using Parso.Util;
using ScrapySharp.Extensions;
using ScrapySharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parso.HtmlParser.CustomParser
{
    public class CarrefourHtmlParser : HtmlParser, IProductParser<ParsoProduct, ParsoCatalog>
    {
        public CarrefourHtmlParser() : base(Common.Enum.ParsoApplicationType.Carrefour) { }
        public CarrefourHtmlParser(string url) : base(url) { }

        public event ParseFinishedEventHandler ParseFinished;

        public List<ParsoProduct> ParseProductList(ParsoCatalog catalog)
        {
            var listOfProducts = GetDocument(catalog.Url).CssSelect(@"div.product");
            var productList = new List<ParsoProduct>();

            foreach (var product in listOfProducts)
            {
                ParsoProduct tmp = new ParsoProduct();

                tmp.ProductId = ParserUtil.GetIntAttribute(product, "id");
                tmp.OldPrice = ParserUtil.GetDecimalValueOfElement(product, @"span.oldprice", @"([\d,]+)");
                tmp.Price = ParserUtil.GetDecimalValueOfElement(product, @"span.price", @"([\d,]+)");
                tmp.ProductName = ParserUtil.GetStringValueOfElement(product, "a.title");
                tmp.PictureUrl = ParserUtil.GetStringAttribute(product, "src", @"img.lazyload");
                tmp.ProductDetailUrl = ParserUtil.GetStringAttribute(product, "href", @"a.title");
                tmp.CatalogId = catalog.Id;
                tmp.ProductDescription = Parse("https://www.carrefoursa.com" + tmp.ProductDetailUrl, @"div.tab-pane.active");
               
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

        public List<ParsoCatalog> ParseCatalogList(long batchId,string rootUrl)
        {
            var urlList = XMLUtil.GetSiteMapUrls(rootUrl);
            var siteMapUrls = urlList.Where(x => x.Contains("katalog-urunleri/")).ToList();

            List<ParsoCatalog> catalogList = new List<ParsoCatalog>();

            foreach (var siteUrl in siteMapUrls)
            {
                var catalogDetail = new ParsoCatalog()
                {
                    Name = siteUrl.Substring(siteUrl.IndexOf("katalog-urunleri/") + 17, siteUrl.Length - siteUrl.IndexOf("katalog-urunleri/") - 17),
                    RootUrl = rootUrl,
                    Url = siteUrl,
                    BatchId = batchId
                };

                catalogDetail.Id = SaveCatalog(catalogDetail);
                catalogList.Add(catalogDetail);
            }

            return catalogList;
        }
    }
}
