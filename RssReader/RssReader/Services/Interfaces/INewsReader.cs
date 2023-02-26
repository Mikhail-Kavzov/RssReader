using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;

namespace RssReader.Services.Interfaces
{
    public interface INewsReader
    {
        SyndicationFeed GetNews();
    }
}