using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class QuestionMenu
    {
        ObservableCollection<QuestionType> list;
        Questionnaire questionnairePage;

        public QuestionMenu(ObservableCollection<QuestionType> l, Questionnaire q)
        {
            list = l;
            questionnairePage = q;
        }

        public ScrollView getLayout()
        {
            ScrollView menuScrollView = new ScrollView();

            menuScrollView.Content = getItems();

            return menuScrollView;
        }

        private StackLayout getItems()
        {
            StackLayout menuLayout = new StackLayout();

            Button menuButton = new Button() { Text = "Questionnaire" };

            menuButton.Clicked += (o, s) => 
            {
                Application.Current.MainPage = new ContentPage() { Content = questionnairePage.getLayout() };
            };

            menuLayout.Children.Add(menuButton);

            foreach (QuestionType q in list)
            {
                menuLayout.Children.Add(getMenuItems(q));
            }

            return menuLayout;
        }

        private Frame getMenuItems(QuestionType q)
        {
            Frame menuItem = new Frame();

            Switch enabler = new Switch() { IsToggled = q.IsEnabled};

            enabler.Toggled += (o, s) => { q.IsEnabled = enabler.IsToggled; };

            StackLayout frameLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label () { Text = q.Title },
                    enabler
                }
            };

            menuItem.Content = frameLayout;

            return menuItem;
        }
    }
}
