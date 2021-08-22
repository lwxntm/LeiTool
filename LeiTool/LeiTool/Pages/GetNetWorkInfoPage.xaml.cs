using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeiTool.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetNetWorkInfoPage : ContentPage
    {
        public GetNetWorkInfoPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var hc = new HttpClient();
            var s1=await hc.GetStringAsync("https://api.ip.sb/geoip");
            await this.DisplayAlert("网络信息", $"{s1}" ,"确认");
        }
    }
}