using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using wa_mvc_itstep_hometask_News_Site.Models.Helpers;
using wa_mvc_itstep_hometask_News_Site.Utils.Exstensions;

namespace wa_mvc_itstep_hometask_News_Site.Services.Rss
{
    public class EvilInfoRss
    {
        private readonly static string baseUrl = "https://www.vedomosti.ru/rss";

        public async Task<List<News>> GetNewsAsync(string path)
        {
            List<News> newsList = new();

            string url = baseUrl + path;

            HttpClient httpClient = new();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            XmlDocument xmlDocument = new();

            xmlDocument.LoadXml(result);

            XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("item");

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                News news = new();

                foreach (XmlNode childXmlNode in xmlNode.ChildNodes)
                {
                    switch (childXmlNode.Name)
                    {
                        case "title": news.Title = childXmlNode.InnerText; break;
                        case "link": news.Link = childXmlNode.InnerText; break;
                        case "author": news.Author = childXmlNode.InnerText; break;
                        case "enclosure": news.ImageLink = childXmlNode.Attributes.GetNamedItem("url").Value; break;
                        case "description": news.Description = childXmlNode.InnerText; break;
                        case "category": news.Category = childXmlNode.InnerText; break;
                        case "pubDate": news.PublicationDate = childXmlNode.InnerText.TranslateWeekday().TranslateMonth().Substring(0, childXmlNode.InnerText.LastIndexOf('+')); break;
                    }
                }

                if (!news.Link.Contains("test") && !news.Link.Contains("galleries"))
                    newsList.Add(news);
            }

            return newsList;
        }
    }
}
