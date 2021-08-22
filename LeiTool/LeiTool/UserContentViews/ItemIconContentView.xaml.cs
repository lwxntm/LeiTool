using LeiTool.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeiTool.UserContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemIconContentView : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(ItemIconContentView));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty IconStringProperty =
            BindableProperty.Create("IconString", typeof(string), typeof(ItemIconContentView));
        public string IconString
        {
            get => (string)GetValue(IconStringProperty);
            set => SetValue(IconStringProperty, value);
        }
        public static readonly BindableProperty GoToPageProperty =
            BindableProperty.Create("GoToPage", typeof(ContentPage), typeof(ItemIconContentView));
        public ContentPage GoToPage
        {
            get => (ContentPage)GetValue(GoToPageProperty);
            set => SetValue(GoToPageProperty, value);
        }

        public ItemIconContentView()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            //await Shell.Current.GoToAsync("//TangShiPage");
            await this.Navigation.PushAsync(GoToPage);
        }
    }
}