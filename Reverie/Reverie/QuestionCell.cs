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
        private bool isExpanded;

        private Label tempCell;
        private int numClicked;

        public QuestionCell()
        {
            titleLabel = new Label();

            numClicked = 0;

            tempCell = new Label() { Text = "I'm a temporary child!" };

            titleLabel.SetBinding(Label.TextProperty, "Title");

            createChildrenLayout();

            cellView = new StackLayout()
            {
                Children = { titleLabel, childrenLayout}
            };

            // Bind cell visibility to IsEnabled property of QuestionType
            cellView.SetBinding(StackLayout.IsVisibleProperty, "IsEnabled");
            // Toggle height based off of visibility 
            cellView.PropertyChanged += layoutPropertyChangedHandler;

            View = cellView;
        }

        private void createChildrenLayout()
        {
            childrenLayout = new StackLayout();

            // Bind IsExpanded property to IsExpanded property of QuestionType
            childrenLayout.SetBinding(StackLayout.IsEnabledProperty, "IsExpanded");
            // Is Expanded property Change handler.
            childrenLayout.PropertyChanged += expandedPropertyChangeHandler;
        }

        private void layoutPropertyChangedHandler(object s, EventArgs e)
        {
            if (cellView.IsVisible == false)
            {
                // Make height of cells 0 when invisible so it does not take up space
                cellView.HeightRequest = 0;
            }
            else
            {
                // Make height of cells back to default when it is visible
                cellView.HeightRequest = -1;
            }            
        }

        private void expandedPropertyChangeHandler(object s, EventArgs e)
        {
            if (childrenLayout.IsEnabled != isExpanded)
            {
                isExpanded = childrenLayout.IsEnabled;
                numClicked++;

                if (isExpanded)
                    childrenLayout.Children.Add(tempCell);
                else
                    childrenLayout.Children.Remove(tempCell);
            }
        }
    }
}
