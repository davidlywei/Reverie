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
            reader = new QuestionReader();

            getQuestions();

            view = v;

            Content = getLayout();
        }

        private StackLayout getLayout()
        {
            //Button menuButton = new Button() { Text = "Menu" };
            //menuButton.Clicked += (o, s) => { view.gotoMenu(); };

            Image menuImg = new Image() { Source = ImageSource.FromResource(ReverieUtils.MENU_ICON) };
            menuTGR = new TapGestureRecognizer();
            menuTGR.Tapped += (o, s) => { view.gotoMenu(); };
            Frame menuFrame = new Frame
            {
                Padding = ReverieUtils.BUTTON_PADDING,
                Content = menuImg,
            };
            menuFrame.GestureRecognizers.Add(menuTGR);

            Image doneImg = new Image() { Source = ImageSource.FromResource(ReverieUtils.DONE_ICON) };
            doneTGR = new TapGestureRecognizer();
            doneTGR.Tapped += (o, s) => { view.gotoPasswordPage(); };
            Frame doneFrame = new Frame
            {
                Padding = ReverieUtils.BUTTON_PADDING,
                Content = doneImg,
            };
            doneFrame.GestureRecognizers.Add(doneTGR);

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

            StackLayout navigationBar = new StackLayout()
            {
                Padding = ReverieUtils.LAYOUT_PADDING,
                BackgroundColor = ReverieStyles.accentGreen,
                Orientation = StackOrientation.Horizontal,
                Children = { menuLayout, doneLayout}
            };

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
            String[] questions = reader.getQuestions();

            list = new ObservableCollection<QuestionType>();

            for (int i = 1; i < questions.Length; i++)
                list.Add(new QuestionType(questions[i]));

        }

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
