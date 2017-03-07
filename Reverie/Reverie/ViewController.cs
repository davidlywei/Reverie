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

        
        private const bool FORCE_TUTORIAL = false;

		private LoadingPage loading;
		private TutorialPage tutorial;
        private Questionnaire question;
        private QuestionMenu menu;
		private PasswordPage password;
        private Purpose purpose;
        private int tutorialItr;

        // Value to pass percentage
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
		static readonly string[] imageSource = { "Reverie.Images.TutorialPage1.png",
												"Reverie.Images.TutorialPage2.png", 
												"Reverie.Images.TutorialPage3.png" };

        private const String TUTORIAL_VIEWED = "Tutorial Viewed";

        public ViewController()
        {
            Navigation.PushModalAsync(new LoadingPage(this));

            tutorialItr = 0;

            // Create Purpose page
            purpose = new Purpose(this);

            //update progress bar (not used anymore)
			Percentage += ReverieUtils.QUESTIONNAIRE_PERCENT;
			       
			//update progress bar
			Percentage += ReverieUtils.QUESTIONMENU_PERCENT;

            // Goto first page, either tutorial or purpose
            gotoFirstPage();

            // Assign MainLayout size Change Handler
            //mainLayout.SizeChanged += sizeChangeHandler;
        }

        // Display tutorial page from beginning
        public async void gotoTutorial()
        {
            tutorialItr = 0;
            gotoNextTutorialPage(true);
        }

        // Remove all tutorial pages
        public async void popTutorials()
        {
            for (int i = 0; i < imageSource.Length; i++)
                await Navigation.PopModalAsync();
        }

        // Load next tutorial page
        public async void gotoNextTutorialPage(bool gotoMenu)
        {
            await Navigation.PushModalAsync(new TutorialPage(   this, 
                                                                imageSource[tutorialItr], 
                                                                (tutorialItr + 1 >= imageSource.Length), gotoMenu));
            tutorialItr++;
        }

        // Goto purpose page, and reset pages in modal stack
		public async void gotoPurposePage()
		{
            while (Navigation.ModalStack.Count > 0)
            {
                await Navigation.PopModalAsync();
            }

            purpose.clear();

            await Navigation.PushModalAsync(purpose);
		}

        // goto password page
        public async void gotoPasswordPage()
        {
            await Navigation.PushModalAsync(new PasswordPage(this));
        }

        // goto questionnaire page, Create new questionnaire each time
        // to clear results
        public async void gotoQuestionnaire()
        {

            // Create Questionnaire page
            question = new Questionnaire(this);
            
            // Create Menu page
            menu = new QuestionMenu(question.getList(), this);

            await Navigation.PushModalAsync(question);
        }

        // Goto menu page
        public async void gotoMenu()
        {
            await Navigation.PushModalAsync(menu);
        }

        // go back one page
        public async void backOnePage()
        {
            await Navigation.PopModalAsync();
        }

        // goto first page
        public async void gotoFirstPage()
        {
            Application app = Application.Current;

            // Added testing element to force the tutorial if necessary
            //if (!app.Properties.ContainsKey((FORCE_TUTORIAL ? "Dummy String" : TUTORIAL_VIEWED)))
            if (!app.Properties.ContainsKey(TUTORIAL_VIEWED))
            {
                //if(!FORCE_TUTORIAL)
                app.Properties[TUTORIAL_VIEWED] = true;
                gotoNextTutorialPage(false);
            }
            else
            {
                gotoPurposePage();
            }
        }

        // Get responses from purpose and questionnaire
        public String getResponse()
        {
            String response = "";

			response += purpose.getResponse();
            response += question.getResponse();

            return response; 
        }

        // Get special characters
        public char[] getSpecialChars()
        {
            return menu.getSpecialChars();
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
