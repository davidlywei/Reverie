using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class ViewController : ContentPage
    {
		private LoadingPage loading;
		private TutorialPage tutorial;
        private Questionnaire question;
        private QuestionMenu menu;
		private PasswordPage password;
        private Purpose purpose;
        private double percentage;

        public ViewController()
        {
			//create password page
			//password = new PasswordPage(this);
			//Navigation.PushModalAsync(password);


			/*
			//create loading page
			loading = new LoadingPage(this);


			//create tutorial page
			tutorial = new TutorialPage(this);
			*/

            // Create Purpose page
            purpose = new Purpose(this);

            // Create Questionnaire page
            question = new Questionnaire(this);

			//update progress bar
			//loading.changeProgressBar(ReverieUtils.QUESTIONNAIRE_PERCENT);
			       
            // Create Menu page
            menu = new QuestionMenu(question.getList(), this);

			//update progress bar
			//loading.changeProgressBar(ReverieUtils.QUESTIONMENU_PERCENT);

            Navigation.PushModalAsync(purpose);

            // Assign MainLayout size Change Handler
            //mainLayout.SizeChanged += sizeChangeHandler;


        }

		public async void gotoPurposePage()
		{
			await Navigation.PushModalAsync(new Purpose(this));
		}

        public async void gotoPasswordPage()
        {
            await Navigation.PushModalAsync(new PasswordPage(this));
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

        public String getResponse()
        {
            String response = "";

			response += purpose.getResponse();
            response += question.getResponse();

            return response; 
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
