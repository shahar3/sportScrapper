using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMaster.Model
{
    class MyModel : INotifyPropertyChanged
    {
        private const string BASE_URL = "http://us.soccerway.com/";
        private HtmlDocument htmlDoc;
        private Dictionary<string, string> countryLinks;

        public MyModel()
        {
            initialize();
        }

        private void initialize()
        {
            HtmlWeb web = new HtmlWeb();
            htmlDoc = web.Load(BASE_URL);
            LinkFinder finder = new LinkFinder(htmlDoc);
            countryLinks = finder.getLinks();
            sendSpiders();
        }

        /// <summary>
        /// send spiders simultaneously
        /// </summary>
        private void sendSpiders()
        {
            Spider spider = new Spider(countryLinks["Israel"], BASE_URL);
        }

        #region event triggered
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void notifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
