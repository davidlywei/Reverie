using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class View : ContentPage
    {
        Questionnaire question;

        public View()
        {
            question = new Questionnaire();

            Content = question.getLayout();
            
            // Assign MainLayout size Change Handler
            //mainLayout.SizeChanged += sizeChangeHandler;
        }

        /*
        private void sizeChangeHandler(object sender, EventArgs e)
        {
           // Grab the current Width and Height of the display
            double screenWidth = Application.Current.MainPage.Width;
            double screenHeight = Application.Current.MainPage.Height;

            // Adjust stackLayout to fit screen
            if (screenWidth > screenHeight)
                mainLayout.Orientation = StackOrientation.Horizontal;
            else
                mainLayout.Orientation = StackOrientation.Vertical;
        }
        */

    }
}
