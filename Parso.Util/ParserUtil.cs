using ScrapySharp.Extensions;
using ScrapySharp.Html.Dom;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace Parso.Util
{
    public class ParserUtil
    {
        public static int GetIntAttribute(HElement element, string field)
        {
            int retVal = 0;

            if (element.Attributes != null && element.Attributes.Count > 0 && element.Attributes[field] != null)
            {
                Int32.TryParse(element.Attributes[field], out retVal);
            }

            return retVal;
        }

        public static string GetStringAttribute(HElement element, string field)
        {
            string retVal = String.Empty;

            if (element.Attributes != null && element.Attributes.Count > 0 && element.Attributes[field] != null)
            {
                retVal = Convert.ToString(element.Attributes[field]);
            }

            return retVal;
        }

        public static string GetStringAttribute(HElement element, string field, string selector)
        {
            string retVal = String.Empty;
            NameValueCollection attributeList = null;

            if (!String.IsNullOrWhiteSpace(selector))
            {
                attributeList = element.CssSelect(selector).Single().Attributes;
            }
            else
                attributeList = element.Attributes;


            if (attributeList != null && attributeList.Count > 0 && attributeList[field] != null)
            {
                retVal = Convert.ToString(attributeList[field]);
            }

            return retVal;
        }



        public static decimal GetDecimalValueOfElement(HElement element, string selector, string pattern)
        {
            decimal retVal = 0;
            string temp = String.Empty;

            if (!String.IsNullOrEmpty(pattern))
                temp = Regex.Match(element.CssSelect(selector).Single().InnerText, pattern).Value;
            else
                temp = element.CssSelect(selector).Single().InnerText;

            if (!String.IsNullOrEmpty(temp))
                retVal = Convert.ToDecimal(temp);

            return retVal;
        }


        public static decimal GetDecimalValueOfElement(HElement element, string selector)
        {
            return GetDecimalValueOfElement(element, selector, String.Empty);
        }


        public static string GetStringValueOfElement(HElement element, string selector, string pattern)
        {
            string retVal = String.Empty;

            if (!String.IsNullOrEmpty(pattern))
                retVal = Regex.Match(element.CssSelect(selector).Single().InnerText, pattern).Value;
            else
                retVal = element.CssSelect(selector).Single().InnerText;

            return retVal;
        }

        public static string GetStringValueOfElement(HElement element, string selector)
        {
            return GetStringValueOfElement(element, selector, String.Empty);
        }
    }
}
