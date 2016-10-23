using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FootballMaster.Model
{
    /// <summary>
    /// This class looks for the relevant country link and adds the url to a list
    /// </summary>
    class LinkFinder
    {
        private Dictionary<string,string> links; //country name, url link
        private HtmlDocument doc;
        private const string BASE_URL = "http://us.soccerway.com/";

        public LinkFinder(HtmlDocument doc)
        {
            this.doc = doc;
            links = new Dictionary<string, string>();
            extractLinks();
        }

        /// <summary>
        /// parse the doc and get the links from it
        /// </summary>
        private void extractLinks()
        {
            //1 - extract the html tags from the country list
            HtmlNode[] listNodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/select[2]")[0].ChildNodes.ToArray();
            int index = 0;
            string link = "";
            foreach (HtmlNode node in listNodes)
            {
                if (index > 2 && index % 2 == 0)
                {
                    //get the url
                    link = BASE_URL + node.GetAttributeValue("value","");
                    index++;
                }
                else
                {
                    if (index >= 4)
                    {
                        //get the country name
                        string countryName = node.InnerText.Trim();
                        links[countryName.Substring(0,countryName.IndexOf("(")-1)] = link;
                    }
                    index++;
                    continue;
                }
            }
        }

        public Dictionary<string,string> getLinks()
        {
            return links;
        }
    }
}
