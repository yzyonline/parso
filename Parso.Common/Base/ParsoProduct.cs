using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parso.Common
{

    public class ParsoProduct : EntityBase
    {
        public string ProductName { get; set; }
        public long ProductId { get; set; }
        public string ProductDescription { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDetailUrl { get; set; }
        public string PictureUrl { get; set; }
        public long CatalogId { get; set; }
        public string DiscountDetail { get; set; }

        public override string ToString()
        {
            return this.ProductName;
        }

    }
}
