using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGetSendJson
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Listagem());
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
