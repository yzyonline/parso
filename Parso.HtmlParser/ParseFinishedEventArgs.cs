using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parso.HtmlParser
{
    public class ParseFinishedEventArgs : EventArgs
    {
        private long _catalogId;
        public ParseFinishedEventArgs(long catalogId)
        {
            this._catalogId = catalogId;
        }
        public long CatalogId
        {
            get
            {
                return _catalogId;
            }
        }
    }
}
