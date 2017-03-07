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
        private ObservableCollection<QuestionType> list;
        private ViewController view;
        private TapGestureRecognizer backTGR;
        private Entry spcCharEntry;
        private const String SPECIAL_CHARACTERS = "Special Characters";

        public QuestionMenu(ObservableCollection<QuestionType> l, ViewController v)
        {
            list = l;
            view = v;

            Content = getLayout();
        }

        // Create Layout
        private ScrollView getLayout()
        {
            ScrollView menuScrollView = new ScrollView();

            menuScrollView.Content = getItems();

            return menuScrollView;
        }

        // Create Items
        private StackLayout getItems()
        {
            StackLayout menuLayout = new StackLayout();

            // Add back button to layout
            Image backImg = new Image() { Source = ImageSource.FromResource(ReverieUtils.BACK_ICON) };
            backTGR = new TapGestureRecognizer();
            backTGR.Tapped += (o, s) => { view.backOnePage(); };
            Frame backFrame = new Frame
            {
                Padding = ReverieUtils.BUTTON_PADDING,
                Content = backImg,
            };
            backFrame.GestureRecognizers.Add(backTGR);

            // Create layout for back button
            StackLayout backLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { backFrame }
            };

            // Create padding layout to force back button to left side
            StackLayout paddingLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { new Label() { Text = " "} }
            };

            // Create layout for controls
            StackLayout controlLayout = new StackLayout()
            {
                Padding = ReverieUtils.LAYOUT_PADDING,
                BackgroundColor = ReverieStyles.accentGreen,
                Orientation = StackOrientation.Horizontal,
                Children = { backLayout, paddingLayout}
            };

            // Add control layout
            menuLayout.Children.Add(controlLayout);

            // Add default items
            addDefaultMenuItems(menuLayout);

            // Add items from question list
            foreach (QuestionType q in list)
            {
                menuLayout.Children.Add(getMenuItems(q));
            }

            return menuLayout;
        }

        // Create layout for Menu Items
        private Frame getMenuItems(QuestionType q)
        {
            Frame menuItem = new Frame();

            // Get text for the item, and create layout
            Label itemText = new Label() { Text = q.Title };
            StackLayout textLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { itemText }
            };

            // Create enabler, and set it to modify questionType IsEnabled
            Switch enabler = new Switch() { IsToggled = q.IsEnabled};
            enabler.Toggled += (o, s) => { q.IsEnabled = enabler.IsToggled; };
            StackLayout enablerLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { enabler }

            };

            // package it all in a frame
            StackLayout frameLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { textLayout, enablerLayout }
            };

            menuItem.Content = frameLayout;

            return menuItem;
        }

        // Add items default to the menu
        private void addDefaultMenuItems(StackLayout layout)
        {
            // Create View Tutorial
            Button gotoTutBtn = new Button { Text = "View Tutorial" };
            gotoTutBtn.Clicked += (o, s) => { view.gotoTutorial(); };

            Frame tutFrame = new Frame()
            {
                HorizontalOptions = LayoutOptions.Center,
                Content = gotoTutBtn
            };

            // Create special character layout
            Application app = Application.Current;
            spcCharEntry = new Entry() { Placeholder = "Enter your special characters here"};
            spcCharEntry.TextChanged += (o, s) => { app.Properties[SPECIAL_CHARACTERS] = spcCharEntry.Text; };

            if (app.Properties.ContainsKey(SPECIAL_CHARACTERS))
            {
                spcCharEntry.Text = (String)app.Properties[SPECIAL_CHARACTERS];
            }
            else
            {
                spcCharEntry.Text = "!@#$%^&*";
            }

            StackLayout spcCharLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label() { Text = "Password Special Characters" },
                    spcCharEntry
                }
            };

            Frame spcCharFrame = new Frame() { Content = spcCharLayout };

            layout.Children.Add(tutFrame);
            layout.Children.Add(spcCharFrame);
        }

        // Return special character list
        public char[] getSpecialChars()
        {
            return spcCharEntry.Text.ToCharArray();
        }
    }
}
