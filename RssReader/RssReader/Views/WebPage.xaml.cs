using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RssReader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {

        public WebPage(string url)
        {
            InitializeComponent();
            webView.Source= new Uri(url);
        }

        private void backBtn_Clicked()
        {

        }
    }
}