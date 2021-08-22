using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeiTool.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeiTool
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CiSongDetialPage), typeof(CiSongDetialPage));
          
        }
    }
}