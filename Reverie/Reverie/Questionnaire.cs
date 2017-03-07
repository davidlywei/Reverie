using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class Questionnaire : ContentPage
    {
        ObservableCollection<QuestionType> list;
        ViewController view;
        QuestionReader reader;
        TapGestureRecognizer menuTGR;
        TapGestureRecognizer doneTGR;

        public Questionnaire(ViewController v)
        {
            // Create new reader to read questions from JSON file
            reader = new QuestionReader();

            // Get questions
            getQuestions();

            view = v;

            // Create layout
            Content = getLayout();
        }

        private StackLayout getLayout()
        {
            // Create menu image button
            Image menuImg = new Image() { Source = ImageSource.FromResource(ReverieUtils.MENU_ICON) };
            menuTGR = new TapGestureRecognizer();
            menuTGR.Tapped += (o, s) => { view.gotoMenu(); };
            Frame menuFrame = new Frame
            {
                Padding = ReverieUtils.BUTTON_PADDING,
                Content = menuImg,
            };
            menuFrame.GestureRecognizers.Add(menuTGR);

            // Create done Image button
            Image doneImg = new Image() { Source = ImageSource.FromResource(ReverieUtils.DONE_ICON) };
            doneTGR = new TapGestureRecognizer();
			doneTGR.Tapped += (o, s) => { view.gotoPasswordPage(); };
            Frame doneFrame = new Frame
            {
                Padding = ReverieUtils.BUTTON_PADDING,
                Content = doneImg,
            };
            doneFrame.GestureRecognizers.Add(doneTGR);

            // Layouts for menu and button. They have separate layouts to force them to 
            // opposite ends of the screen
            StackLayout menuLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { menuFrame}
            };

            StackLayout doneLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { doneFrame}
            };

            // Combine layouts for menu and button 
            StackLayout navigationBar = new StackLayout()
            {
                Padding = ReverieUtils.LAYOUT_PADDING,
                BackgroundColor = ReverieStyles.accentGreen,
                Orientation = StackOrientation.Horizontal,
                Children = { menuLayout, doneLayout}
            };

            // StackLayout to attempt to force iOS Listview to expand properly
			StackLayout CPMA = new StackLayout()
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = 
				{ 
				    // AccordionLayout
                    new AccordionLayout()
					{
                        // Set template for items
                        ItemTemplate = new DataTemplate(typeof(QuestionCell)),

                        // Add items to ItemSource
                        ItemsSource = list,

						HasUnevenRows = true
					}
				}
			};

            // Overall questionnaire page layout
            StackLayout qLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    // Menu
                    navigationBar,
					// AccordionLayout
					CPMA
                 }
            };

            return qLayout;
        }

        private void getQuestions()
        {
            // Get question Strings from reader
            String[] questions = reader.getQuestions();

            // Create obs-col to store questions
            list = new ObservableCollection<QuestionType>();

            // add a new QuestionType for each string (except for the header string)
            for (int i = 1; i < questions.Length; i++)
                list.Add(new QuestionType(questions[i]));
        }

        // To string method unused for now. Might be used for Custom Quesions
        public String toString(String Title, bool IsEnabled, int idValue, String childrenString)
        {
            String questionString = "{";

            questionString += "\"" + ReverieUtils.JSON_TAG_TITLE + "\":\"";
            questionString += Title + "\",";
            questionString += "\"" + ReverieUtils.JSON_TAG_ENABLE + "\":\"";
            questionString += (IsEnabled ? Boolean.TrueString : Boolean.FalseString) + "\",";
            questionString += "\"" + ReverieUtils.JSON_TAG_ID + "\":\"";
            questionString += idValue + "\",";
            questionString += "\"" + ReverieUtils.JSON_TAG_QLIST + "\":[";
            questionString += childrenString + "]}";

            return questionString;
        }

        public ObservableCollection<QuestionType> getList()
        {
            return list;
        }

        // Returns responses gathered from all QuestionTypes
        public String getResponse()
        {
            String response = "";

            foreach (QuestionType q in list)
            {
                response += q.getResponse();
            }

            return response;
        }
    }
}
