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

        public static readonly BindableProperty IsExpandedProperty =
            BindableProperty.Create("IsExpanded", typeof(bool), typeof(QuestionType), false);
        public bool IsExpanded
        {
            get { return (bool) GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); } 
        }

        public QuestionCell()
        {
            titleLabel = new Label();

            titleLabel.SetBinding(Label.TextProperty, "Title");

            cellView = new StackLayout()
            {
                Children = { titleLabel }
            };

            // Bind cell visibility to IsEnabled property of QuestionType
            cellView.SetBinding(StackLayout.IsVisibleProperty, "IsEnabled");
            // Toggle height based off of visibility 
            cellView.PropertyChanged += layoutPropertyChangedHandler;

            // Bind IsExpanded property to IsExpanded property of QuestionType
            //this.SetBinding(IsExpandedProperty, "IsExpanded");
            // Is Expanded property Change handler.
            //this.PropertyChanged += OnExpanded;

            createChildrenLayout();

            View = cellView;
        }

        private void createChildrenLayout()
        {
            childrenLayout = new StackLayout() { Children = { new Label() { Text = "Expanded" } } };
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

                if (IsExpanded == true)
                    cellView.HeightRequest = cellView.Height + childrenLayout.Height;
            }            
        }

        private void OnExpanded(object s, EventArgs e)
        {
            if (IsExpanded)
                cellView.Children.Add(childrenLayout);
            else
                cellView.Children.Remove(childrenLayout);
        }
    }
}
