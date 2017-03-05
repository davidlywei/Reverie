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

        private List<Question> qList;
        private Dictionary<String, String> questionHistory;

        private static readonly BindableProperty ChildrenProperty =
            BindableProperty.Create("Children", typeof(String), typeof(QuestionCell), "Child");
        public String Children
        {
            set { SetValue(ChildrenProperty, value); }
            get { return (String) GetValue(ChildrenProperty); }    
        }

        private static readonly BindableProperty ResponseProperty =
            BindableProperty.Create("Response", typeof(String), typeof(QuestionCell), "", BindingMode.TwoWay);
        public String Response
        {
            set { SetValue(ResponseProperty, value); }
            get { return (String) GetValue(ResponseProperty); }    
        }

        public QuestionCell()
        {
            titleLabel = new Label();

            qList = new List<Question>();

            questionHistory = new Dictionary<string, string>();

            this.SetBinding(ChildrenProperty, "ChildrenJSON");
            this.PropertyChanged += childrenPropertyChangeHandler;

            tempCell = new Label() { Text = Children };

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
                {
                    foreach (Question q in qList)
                    {
                        childrenLayout.Children.Add(q.getLayout());
                    }
                }
                else
                {
                    for (int i = 0; i < childrenLayout.Children.Count; i++)
                        childrenLayout.Children.RemoveAt(i);
                }
            }
        }

        private void childrenPropertyChangeHandler(object s, EventArgs e)
        {
            parseChildren(Children);
        }

        private void parseChildren(String children)
        {
            String[] words = children.Split(ReverieUtils.DELIMITERS);

            // Remove empty strings
            words = words.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            for (int i = 1; i < words.Length; i++)
            {
                switch (words[i])
                {
                    case ReverieUtils.QUESTION_TEXT:
                        String prompt = words[i + 2];
                        String placeholder = words[i + 4];

                        if (!questionHistory.ContainsKey(prompt))
                        {
                            questionHistory.Add(prompt, placeholder);
                            qList.Add(new QuestionText(prompt, placeholder));
                            i += 4;
                        }

                        break;
                }
            }
        }
    }
}
