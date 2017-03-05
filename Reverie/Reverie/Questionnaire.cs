using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class Questionnaire
    {
        ObservableCollection<QuestionType> list;
        QuestionMenu menu;

        public Questionnaire()
        {
            getQuestions();

            menu = new QuestionMenu(list, this);
        }

        public StackLayout getLayout()
        {
            Button menuButton = new Button() { Text = "Menu" };

            menuButton.Clicked += (o, s) => 
            {
                Application.Current.MainPage = new ContentPage() { Content = menu.getLayout() };
            };

            StackLayout qLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    // Menu
                    menuButton,
                    // AccordionLayout
                    new AccordionLayout()
                    {
                        // Set template for items
                        ItemTemplate = new DataTemplate(typeof(QuestionCell)),

                        // Add items to ItemSource
                        ItemsSource = list,

                        HasUnevenRows = true,
                    }
                }
            };

            return qLayout;
        }

        private void getQuestions()
        {
            String testString = "QuestionList\":[{\"Type\":\"" + ReverieUtils.QUESTION_TEXT + "\",\"Prompt\":\"Test Question\",\"Placeholder\":\"Enter your response here\"}";

            list = new ObservableCollection<QuestionType>();

            for (int i = 0; i < 10; i++)
                list.Add(new QuestionType(toString("Question #" + i, true, i, testString)));
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

    }
}
