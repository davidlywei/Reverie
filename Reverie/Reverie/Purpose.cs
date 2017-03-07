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
            
            // Create Entry to hold purpose
            purposeEntry = new Entry()
            {
                Placeholder = "Enter your purpose here",
                Text = ""
            };

            // Create instruction label
            Label instructionLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                Text = "Enter the purpose for your password:"
            };

            // Create warning label to tell users to enter in more than 3 characters
            warningLabel = new Label()
            {
                IsVisible = false,
                TextColor = Color.Red,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Invalid entry\nYour prupose must be at least 4 letter long!"
            };

            // Create layout for warning label
            StackLayout warningLayout = new StackLayout()
            {
                HeightRequest = 200,
                Children = { warningLabel }
            };

            // Create submit button
            Button submitBtn = new Button()
            {
                Text = "Submit"
            };
            submitBtn.Clicked += (o, s) =>
            {
                // Reject password if text is empty or less than 4 chars
                if (purposeEntry.Text == "" || purposeEntry.Text.Length <= 3)
                {
                    warningLabel.IsVisible = true;
                }
                else
                {
                    view.gotoQuestionnaire();
                }
            };

            // Main layout for purpose
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

        // Returns response from entry
        public String getResponse()
        {
            return purposeEntry.Text;
        }

        // Clears entry
        public void clear()
        {
            purposeEntry.Text = "";
        }
    }
}
