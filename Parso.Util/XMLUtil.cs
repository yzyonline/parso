using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Parso.Util
{
    public class XMLUtil
    {
        public static IEnumerable<string> GetSiteMapUrls(string url)
        {
            List<string> urls = new List<string>();
            XmlReader xmlReader = new XmlTextReader(url);

            XPathDocument document = new XPathDocument(xmlReader);
            XPathNavigator navigator = document.CreateNavigator();

            XmlNamespaceManager resolver = new XmlNamespaceManager(xmlReader.NameTable);
            resolver.AddNamespace("sitemap", "http://www.sitemaps.org/schemas/sitemap/0.9");

            XPathNodeIterator iterator = navigator.Select("/sitemap:urlset/sitemap:url/sitemap:loc", resolver);

            while (iterator.MoveNext())
            {
                if (iterator.Current == null)
                    continue;

                urls.Add(iterator.Current.Value);
            }

            return urls;
        }

    }
}
