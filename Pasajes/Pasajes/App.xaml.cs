using Pasajes.Bootstrap;
using Xamarin.Forms;

namespace Pasajes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
