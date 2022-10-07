using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChatView.Models;
namespace ChatView
{
    public partial class App : Application
    {
        public static string MainIconURI = "https://zongkers.com/wp-content/uploads/2019/07/3c46c-full-width-image-9.jpg";
        public static string MainName ="Xamarin";
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
