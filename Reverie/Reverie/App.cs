using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Reverie
{
    public class App : Application
    {
        View view;

        public App()
        {
            // Instantiate it with a new controller
            view = new View();

            MainPage = new NavigationPage(new View());

            // Set Styles from PhotoFrameStyles file and 
            // load it into the default dictionary.
            Current.Resources = new ResourceDictionary();

            foreach (Style s in ReverieStyles.STYLES)
            {
                Current.Resources.Add(s);
            }
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
