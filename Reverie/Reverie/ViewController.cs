using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class ViewController : ContentPage
    {
        private Questionnaire question;
        private QuestionMenu menu;
        private double percentage;

        public ViewController()
        {
            percentage = 0;

            // Create Questionnaire page
            question = new Questionnaire(this);
            changePercentage(ReverieUtils.QUESTIONNAIRE_PERCENT);

            // Create Menu page
            menu = new QuestionMenu(question.getList(), this);
            changePercentage(ReverieUtils.QUESTIONMENU_PERCENT);

            Navigation.PushModalAsync(question);

            // Assign MainLayout size Change Handler
            //mainLayout.SizeChanged += sizeChangeHandler;
        }

        public async void gotoQuestionnaire()
        {
            await Navigation.PushModalAsync(question);
        }

        public async void gotoMenu()
        {
            await Navigation.PushModalAsync(menu);
        }

        public async void backOnePage()
        {
            await Navigation.PopModalAsync();
        }

        private void changePercentage(double percent)
        {
            percentage += percent;

            // Insert call to change percentage page
             
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
