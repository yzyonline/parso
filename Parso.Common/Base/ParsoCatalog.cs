using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parso.Common.Base
{
    public class ParsoCatalog : EntityBase
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string PictureUrl { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
        public string RootUrl { get; set; }
        public long BatchId { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
