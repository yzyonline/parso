using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parso.HtmlParser
{
    public class JSONParser<T>
    {
        public List<T> Parse(string url)
        {
            List<T> listOfObjects = new List<T>();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string response = String.Empty;
            var request = (HttpWebRequest)WebRequest.Create(new Uri(url));

            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.ServicePoint.ConnectionLimit = 1;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.UseDefaultCredentials = true;


            WebResponse httpResponse = request.GetResponse();

            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                response = reader.ReadToEnd();
            try
            {
                listOfObjects = (List<T>)JsonConvert.DeserializeObject(Convert.ToString(response), typeof(List<T>), new JsonSerializerSettings());
            }
            catch (Exception ex)
            {
                response = "[{\"categoryId\":30008,\"name\":\"Bebek, Oyuncak\",\"shopCategoryId\":30008,\"productModelCount\":0},{\"categoryId\":30009,\"name\":\"Ev, Pet\",\"shopCategoryId\":30009,\"productModelCount\":0},{\"categoryId\":30001,\"name\":\"Meyve, Sebze\",\"shopCategoryId\":30001,\"productModelCount\":0},{\"categoryId\":30002,\"name\":\"Et, Balık\",\"shopCategoryId\":30002,\"productModelCount\":0},{\"categoryId\":30003,\"name\":\"Süt, Kahvaltılık\",\"shopCategoryId\":30003,\"productModelCount\":0},{\"categoryId\":30004,\"name\":\"Gıda, Şekerleme\",\"shopCategoryId\":30004,\"productModelCount\":0},{\"categoryId\":30005,\"name\":\"İçecek\",\"shopCategoryId\":30005,\"productModelCount\":0},{\"categoryId\":30006,\"name\":\"Deterjan, Temizlik\",\"shopCategoryId\":30006,\"productModelCount\":0},{\"categoryId\":30007,\"name\":\"Kağıt, Kozmetik\",\"shopCategoryId\":30007,\"productModelCount\":0}]";
                listOfObjects = (List<T>)JsonConvert.DeserializeObject(Convert.ToString(response), typeof(List<T>), new JsonSerializerSettings());
            }
            return listOfObjects;
        }


        public T ParseDetail(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string response = String.Empty;
            var request = (HttpWebRequest)WebRequest.Create(new Uri(url));

            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.ServicePoint.ConnectionLimit = 1;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.UseDefaultCredentials = true;


            WebResponse httpResponse = request.GetResponse();

            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                response = reader.ReadToEnd();

            return (T)JsonConvert.DeserializeObject(Convert.ToString(response), typeof(T), new JsonSerializerSettings());
        }

    }
}
