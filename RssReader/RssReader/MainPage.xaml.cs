using RssReader.Services.Implementation;
using RssReader.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RssReader
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel MainViewModel { get; set; } = new MainViewModel();

        private INewsReader _reader;
        private string prevText = "";

        private const string URL = "https://rss.nytimes.com/services/xml/rss/nyt/Europe.xml";
        private const int TIMER_INTERVAL = 20000;
        

        private readonly Timer _timer;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = MainViewModel;
            _reader = new UrlNewsReader(URL);
            _timer = new Timer(ReadRss, null, 0, TIMER_INTERVAL);
        }

        public void ReadRss(object state)
        {
            var rssResult = _reader.GetNews();
            if (rssResult.Items.Count() <= 0)
            {
                return;
            }
            // if texts are not equal - update rss
            var lastText = rssResult.Items.ElementAt(0).Title.Text;
            if (prevText != lastText)
            {
                MainViewModel.Items.Clear();
                prevText = lastText;
                foreach (var item in rssResult.Items)
                {
                    MainViewModel.Items.Add(item);
                }
            }
        }

        private async void newsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new WebPage(MainViewModel.SelectedItem.Links[0].Uri.AbsoluteUri));
        }
    }
}
