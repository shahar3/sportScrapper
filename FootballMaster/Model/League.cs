using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;


namespace FootballMaster.Model
{
    class League
    {
        private string leagueName;
        private List<ClubPosition> leagueTable; //we will add the clubs according to their position in the table

        public string LeagueName
        {
            get { return leagueName; }
            set { leagueName = value; }
        }

        public League(HtmlDocument leagueDoc)
        {
            //download the tables page
            getTableDoc(leagueDoc);
        }

        private static void getTableDoc(HtmlDocument doc)
        {
            //get the league name
            HtmlNode nameNode = doc.DocumentNode.SelectNodes("//*[@id=\"subheading\"]/h1")[0];
            string leagueName = nameNode.InnerText;
            //extract the league table
            HtmlNode tableNodes = doc.DocumentNode.SelectNodes("//table")[0];
            int rowNum = 0;
            int position = 1;
            foreach (HtmlNode row in tableNodes.SelectNodes(".//tr"))
            {
                if(rowNum == 0)
                {
                    rowNum++;
                    continue;
                }
                HtmlNode[] cells = row.SelectNodes("td").ToArray();
                if (cells.Length > 2)
                { //check if its a valid row
                    string teamName = cells[2].InnerText;
                    int points = Int32.Parse(cells[10].InnerText);
                    ClubPosition cp = new ClubPosition(position, teamName, points);
                    position++;
                }
            }
        }
    }
}
