using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parso.HtmlParser.CustomEntites
{
    public class MigrosProduct
    {
        public List<object> extData { get; set; }
        public List<AaData> aaData { get; set; }
    }

    public class AaData
    {
        public string nm { get; set; }
        public string psi { get; set; }
        public object pmid { get; set; }
        public int? pid { get; set; }
        public int? sid { get; set; }
        public string cy { get; set; }
        public decimal? prc { get; set; }
        public decimal? mprc { get; set; }
        public object cat { get; set; }
        public object catn { get; set; }
        public string uri { get; set; }
        public string luri { get; set; }
        public string img { get; set; }
        public int? dprc { get; set; }
        public int? fv { get; set; }
        public int? cmp { get; set; }
        public int? his { get; set; }
        public int? mgkp { get; set; }
        public int? mprd { get; set; }
        public int? sa { get; set; }
        public bool ios { get; set; }
        public string ib { get; set; }
        public int? ct { get; set; }
        public string un { get; set; }
        public string una { get; set; }
        public int? uid { get; set; }
        public int? uida { get; set; }
        public object amt { get; set; }
        public string shpcd { get; set; }
        public object nf { get; set; }
        public object dd { get; set; }
        public int? ud { get; set; }
        public int? ui { get; set; }
        public int? aud { get; set; }
        public int? aui { get; set; }
        public object di { get; set; }
        public object oam { get; set; }
        public object paj { get; set; }
        public double? mal { get; set; }
        public double? mil { get; set; }
    }
}
