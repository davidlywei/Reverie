using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class ViewController : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChangedVC;

        private const bool DEBUG = false;

		private LoadingPage loading;
		private TutorialPage tutorial;
        private Questionnaire question;
        private QuestionMenu menu;
		private PasswordPage password;
        private Purpose purpose;
        private int tutorialItr;

        private double percentage;
        public double Percentage
        {
            set
            {
                if (percentage != value)
                {
                    percentage = value;

                    if(PropertyChangedVC != null)
                        PropertyChangedVC(this, new PropertyChangedEventArgs("Percentage"));
                }
            }

            get { return percentage; }
        }

		//array of stirngs containing embedded image sources
		static readonly string[] imageSource = { "Reverie.Images.Logo.png",
												"Reverie.Images.Logo.png", 
												"Reverie.Images.Logo.png" };

        private const String TUTORIAL_VIEWED = "Tutorial Viewed";

        public ViewController()
        {
            Navigation.PushModalAsync(new LoadingPage(this));

            tutorialItr = 0;

            // Create Purpose page
            purpose = new Purpose(this);

            // Create Questionnaire page
            question = new Questionnaire(this);

            //update progress bar
			Percentage += ReverieUtils.QUESTIONNAIRE_PERCENT;
			       
            // Create Menu page
            menu = new QuestionMenu(question.getList(), this);

			//update progress bar
            
			Percentage += ReverieUtils.QUESTIONMENU_PERCENT;

            gotoFirstPage();

            // Assign MainLayout size Change Handler
            //mainLayout.SizeChanged += sizeChangeHandler;
        }

        public async void gotoNextTutorialPage()
        {
            await Navigation.PushModalAsync(new TutorialPage(   this, 
                                                                imageSource[tutorialItr], 
                                                                (tutorialItr + 1 >= imageSource.Length)));
            tutorialItr++;
        }

		public async void gotoPurposePage()
		{
            while (Navigation.ModalStack.Count > 0)
            {
                await Navigation.PopModalAsync();
            }
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

        public async void gotoFirstPage()
        {
            Application app = Application.Current;

            if (!app.Properties.ContainsKey(TUTORIAL_VIEWED))
            {
                app.Properties[TUTORIAL_VIEWED] = true;
                gotoNextTutorialPage();
            }
            else
            {
                gotoPurposePage();
            }
        }

        public String getResponse()
        {
            String response = "";

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
