using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class QuestionMenu : ContentPage
    {
        ObservableCollection<QuestionType> list;
        ViewController view;
        TapGestureRecognizer backTGR;

        public QuestionMenu(ObservableCollection<QuestionType> l, ViewController v)
        {
            list = l;
            view = v;

            Content = getLayout();

            //BackgroundColor = ReverieUtils.PAGE_BACKGROUND_COLOR;
        }

        private ScrollView getLayout()
        {
            ScrollView menuScrollView = new ScrollView();

            menuScrollView.Content = getItems();

            return menuScrollView;
        }

        private StackLayout getItems()
        {
            StackLayout menuLayout = new StackLayout();

            Image backImg = new Image() { Source = ImageSource.FromResource(ReverieUtils.BACK_ICON) };
            backTGR = new TapGestureRecognizer();
            backTGR.Tapped += (o, s) => { view.backOnePage(); };
            Frame backFrame = new Frame
            {
                Padding = ReverieUtils.BUTTON_PADDING,
                Content = backImg,
            };
            backFrame.GestureRecognizers.Add(backTGR);

            StackLayout backLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { backFrame }
            };

            StackLayout paddingLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { new Label() { Text = " "} }
            };

            StackLayout controlLayout = new StackLayout()
            {
                Padding = ReverieUtils.LAYOUT_PADDING,
                BackgroundColor = ReverieStyles.accentGreen,
                Orientation = StackOrientation.Horizontal,
                Children = { backLayout, paddingLayout}
            };

            menuLayout.Children.Add(controlLayout);

            foreach (QuestionType q in list)
            {
                menuLayout.Children.Add(getMenuItems(q));
            }

            return menuLayout;
        }

        private Frame getMenuItems(QuestionType q)
        {
            Frame menuItem = new Frame();

            Label itemText = new Label() { Text = q.Title };
            StackLayout textLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { itemText }
            };

            Switch enabler = new Switch() { IsToggled = q.IsEnabled};
            enabler.Toggled += (o, s) => { q.IsEnabled = enabler.IsToggled; };
            StackLayout enablerLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { enabler }

            };

            StackLayout frameLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { textLayout, enablerLayout }
            };

            menuItem.Content = frameLayout;

            return menuItem;
        }
    }
}
