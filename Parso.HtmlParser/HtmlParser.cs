using HtmlAgilityPack;
using Parso.Common;
using Parso.Common.Base;
using Parso.Common.Enum;
using Parso.Entities;
using ScrapySharp.Extensions;
using ScrapySharp.Html.Dom;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace Parso.HtmlParser
{
    public class HtmlParser
    {

        public delegate void ParseFinishedEventHandler(object sender, ParseFinishedEventArgs e);

        internal string RootUrl;
        internal ParsoApplicationType AppType;
        public HtmlParser(ParsoApplicationType appType)
        {
            AppType = appType;
        }
        public HtmlParser(string url)
        {
            RootUrl = url;
        }

        public HDocument GetDocument(string url)
        {
            HtmlDocument document = new HtmlWeb().Load(url);
            return HDocument.Parse(document.DocumentNode.InnerHtml);
        }

        public string Parse(string url, string tag)
        {
            return Parse(url, tag, false);
        }

        public string Parse(string url, string tag, bool replaceTags)
        {
            string result = String.Empty;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            var workLoad = HDocument.Parse(document.DocumentNode.InnerHtml);
            var selectedItems = workLoad.CssSelect(tag);

            foreach (var item in selectedItems)
                result += item.InnerText;

            return replaceTags ? result.Replace("\r", "").Replace("\t", "").Replace("\n", "") : result;
        }

        public string Parse(HDocument workLoad, string tag,bool replaceTags)
        {
            string result = String.Empty;
            var selectedItems = workLoad.CssSelect(tag);

            foreach (var item in selectedItems)
                result += item.InnerText;

            return replaceTags ? result.Replace("\r", "").Replace("\t", "").Replace("\n", "") : result;
        }

        internal void SaveProduct(ParsoProduct product)
        {
            if (String.IsNullOrWhiteSpace(product.ProductName))
                return;

            try
            {
                ParsoEntities entities = new ParsoEntities();
                entities.Product.Add(new Product()
                {
                    CatalogId = product.CatalogId,
                    Code = product.ProductId.ToString(),
                    Name = product.ProductName,
                    OldPrice = product.OldPrice,
                    Price = product.Price,
                    PictureUrl = product.PictureUrl,
                    ProductUrl = product.ProductDetailUrl,
                    Description = product.ProductDescription,
                    DiscountDetail = product.DiscountDetail,
                    RecordDate = DateTime.Now
                });

                entities.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                   .SelectMany(x => x.ValidationErrors)
                   .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception gex)
            {
                // TODO ADD LOGING

            }
        }

        internal long SaveCatalog(ParsoCatalog catalog)
        {
            try
            {
                ParsoEntities entities = new ParsoEntities();

                Catalog temp = new Catalog()
                {
                    Name = catalog.Name,
                    Description = catalog.Description,
                    RecordDate = DateTime.Now,
                    RootUrl = catalog.RootUrl,
                    Url = catalog.Url,
                    BatchId = catalog.BatchId
                };

                entities.Catalog.Add(temp);
                entities.SaveChanges();
                return temp.Id;
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                   .SelectMany(x => x.ValidationErrors)
                   .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception gex)
            {
                // TODO ADD LOGING
                return -1;
            }
        }
    }
}
