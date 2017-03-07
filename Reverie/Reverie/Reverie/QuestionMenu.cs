﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class QuestionMenu : ContentPage
    {
        ObservableCollection<QuestionType> list;
        ViewController view;

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

            Button menuButton = new Button() { Text = "Questionnaire" };

            menuButton.Clicked += (o, s) => 
            {
                view.backOnePage();
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
