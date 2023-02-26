using RssReader.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace RssReader.Services.Implementation
{
    internal class UrlNewsReader : INewsReader
    {
        private readonly string _url;

        public UrlNewsReader(string url)
        {
            _url= url;
        }

        public SyndicationFeed GetNews()
        {
            using (XmlReader xmlReader = XmlReader.Create(_url))
            {
                return SyndicationFeed.Load(xmlReader);
            }
        }
    }
}