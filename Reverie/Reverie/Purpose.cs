using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class Purpose : ContentPage
    {
        ViewController view;
        StackLayout mainLayout;
        Entry purposeEntry;
        Label warningLabel;

        public Purpose(ViewController v)
        {
            view = v;

            purposeEntry = new Entry()
            {
                Placeholder = "Enter your purpose here",
                Text = ""
            };

            Label instructionLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                Text = "Enter the purpose for your password:"
            };

            warningLabel = new Label()
            {
                IsVisible = false,
                TextColor = Color.Red,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Invalid entry\nYour prupose must be at least 3 letter long!"
            };

            StackLayout warningLayout = new StackLayout()
            {
                HeightRequest = 200,
                Children = { warningLabel }
            };

            Button submitBtn = new Button()
            {
                Text = "Submit"
            };
            submitBtn.Clicked += (o, s) =>
            {
                if (purposeEntry.Text == "" || purposeEntry.Text.Length < 3)
                {
                    warningLabel.IsVisible = true;
                }
                else
                {
                    view.gotoQuestionnaire();
                }
            };

            mainLayout = new StackLayout()
            {
                Padding = ReverieUtils.LAYOUT_PADDING,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children = { instructionLabel, purposeEntry, submitBtn, warningLayout }
            };

            Content = mainLayout;
        }

        public String getResponse()
        {
            return purposeEntry.Text;
        }
    }
}
