using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class Questionnaire : ContentPage
    {
        ObservableCollection<QuestionType> list;
        ViewController view;
        QuestionReader reader;

        public Questionnaire(ViewController v)
        {
            reader = new QuestionReader();

            getQuestions();

            view = v;

            Content = getLayout();
        }

        private StackLayout getLayout()
        {
            Button menuButton = new Button() { Text = "Menu" };
            menuButton.Clicked += (o, s) => { view.gotoMenu(); };

            Button doneButton = new Button() { Text = "Done" };
//            doneButton.Clicked += (o, s) => { view.gotoPasswordPage(); };

            StackLayout navigationBar = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { menuButton, doneButton}
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
