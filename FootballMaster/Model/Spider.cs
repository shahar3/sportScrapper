using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FootballMaster.Model
{
    /// <summary>
    /// Each spider suppose to crawl it's page link to scrape all the data of the 
    /// specific country
    /// </summary>
    class Spider
    {
        private HtmlDocument doc;
        private string baseUrl;

        public Spider(string pageUrl, string baseUrl)
        {
            this.baseUrl = baseUrl;
            //load the country page and store it in doc
            HtmlWeb web = new HtmlWeb();
            doc = web.Load(pageUrl);
            extractData();
        }

        private void extractData()
        {
            //get table link
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//*[@id=\"submenu\"]/ul/li[3]/a").ToArray();
            string tablesLink = baseUrl + nodes[0].GetAttributeValue("href", "");
            HtmlWeb tablesPage = new HtmlWeb();
            HtmlDocument tablesDoc = tablesPage.Load(tablesLink);
            League mainLeague = new League(tablesDoc);

        }
    }
}
