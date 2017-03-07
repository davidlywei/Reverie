using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Reverie
{
    public class App : Application
    {
        ViewController view;

		//screen width for determining tutorial page image size
		static public int screenWidth;
		static public int screenHeight;


        public App()
        {
            // Set Styles from PhotoFrameStyles file and 
            // load it into the default dictionary.
            Current.Resources = new ResourceDictionary();

            foreach (Style s in ReverieStyles.STYLES)
            {
                Current.Resources.Add(s);
            }

            MainPage = new NavigationPage(new ViewController());
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
