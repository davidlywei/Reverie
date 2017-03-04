using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class QuestionCell : ViewCell
    {
        private Label titleLabel;
        private StackLayout cellView;
        private StackLayout childrenLayout;

        private Label clickedLabel;
        private int numClicks;

        public QuestionCell()
        {
            numClicks = 0;

            titleLabel = new Label();

            titleLabel.SetBinding(Label.TextProperty, "Title");

            clickedLabel = new Label() { Text = "Click # " + numClicks };

            createChildrenLayout();

            cellView = new StackLayout()
            {
                Children = { titleLabel, clickedLabel, childrenLayout}
            };

            // Bind cell visibility to IsEnabled property of QuestionType
            cellView.SetBinding(StackLayout.IsVisibleProperty, "IsEnabled");
            // Toggle height based off of visibility 
            cellView.PropertyChanged += layoutPropertyChangedHandler;

            View = cellView;
        }

        private void createChildrenLayout()
        {
            childrenLayout = new StackLayout() { Children = { new Label() { Text = "Expanded" } } };
            
            // Bind IsExpanded property to IsExpanded property of QuestionType
            childrenLayout.SetBinding(StackLayout.IsEnabledProperty, "IsExpanded");
            // Is Expanded property Change handler.
            childrenLayout.PropertyChanged += expandedPropertyChangeHandler;
        }

        private void layoutPropertyChangedHandler(object s, EventArgs e)
        {
            if (cellView.IsVisible == false)
            {
                cellView.HeightRequest = 0;
            }
            else
            {
                cellView.HeightRequest = titleLabel.Height;

                // Xamarin hates these lines of code... do not use
                //if (childrenLayout.IsEnabled == true)
                //    cellView.HeightRequest = titleLabel.Height + childrenLayout.Height;
            }            
        }

        private void expandedPropertyChangeHandler(object s, EventArgs e)
        {
            numClicks++;
            clickedLabel.Text = "Click # " + numClicks ;

            /*
            if (childrenLayout.IsEnabled)
                cellView.Children.Add(childrenLayout);
            else
                cellView.Children.Remove(childrenLayout);
                */
        }
    }
}
