using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class QuestionCell : ViewCell, INotifyPropertyChanged
    {
        private Label titleLabel;
        private Label arrowLabel;
        private StackLayout cellView;
        private StackLayout childrenLayout;
        private bool isExpanded;

        private List<Question> qList;
        private Dictionary<String, String> questionHistory;
        private StackLayout arrowLayout;
        private Image upArrowImage;
        private Image downArrowImage; 
        
        private static readonly BindableProperty ChildrenProperty =
            BindableProperty.Create("Children", typeof(String), typeof(QuestionCell), "Child");
        public String Children
        {
            set { SetValue(ChildrenProperty, value); }
            get { return (String) GetValue(ChildrenProperty); }    
        }
        
        private static readonly BindableProperty ResponsePropertyQC =
            BindableProperty.Create("Response", typeof(String), typeof(QuestionCell), "", BindingMode.OneWayToSource);
        public String Response
        {
            set
            {
                if (value != Response)
                {
                    SetValue(ResponsePropertyQC, value);
                }
            }
            get { return (String) GetValue(ResponsePropertyQC); }    
        }

        public QuestionCell()
        {
            upArrowImage = new Image() { Source = ImageSource.FromResource(ReverieUtils.UP_ICON) };
            downArrowImage = new Image() { Source = ImageSource.FromResource(ReverieUtils.DOWN_ICON) };

            qList = new List<Question>();

            questionHistory = new Dictionary<string, string>();

            this.SetBinding(ChildrenProperty, "ChildrenJSON");
            this.PropertyChanged += childrenPropertyChangeHandler;

            this.SetBinding(ResponsePropertyQC, "ResponseQT");

            createChildrenLayout();

            cellView = new StackLayout()
            {
                Spacing = ReverieUtils.LAYOUT_SPACING,
                Padding = ReverieUtils.LAYOUT_SPACING,
                Children = { createTitle(), childrenLayout}
            };

            // Bind cell visibility to IsEnabled property of QuestionType
            cellView.SetBinding(StackLayout.IsVisibleProperty, "IsEnabled");
            // Toggle height based off of visibility 
            cellView.PropertyChanged += layoutPropertyChangedHandler;

            View = cellView;
        }

        private Frame createTitle()
        {
            titleLabel = new Label() { FontAttributes = FontAttributes.Bold };
            titleLabel.SetBinding(Label.TextProperty, "Title");
            StackLayout titleLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { titleLabel }
            };

            arrowLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { downArrowImage }
            };

            StackLayout headerLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { titleLayout, arrowLayout}
            };
            Frame headerFrame = new Frame() { Content = headerLayout };

            return headerFrame;
        }

        private void createChildrenLayout()
        {
            childrenLayout = new StackLayout()
            {
                Spacing = ReverieUtils.LAYOUT_SPACING,
                Padding = ReverieUtils.LAYOUT_SPACING
            };

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

                if (isExpanded)
                {
                    foreach (Question q in qList)
                    {
                        childrenLayout.Children.Add(q.getLayout());
                    }

                    arrowLayout.Children[0] = upArrowImage;
                }
                else
                {
                    int numChildren = childrenLayout.Children.Count;

                    for (int i = 0; i < numChildren; i++)
                        childrenLayout.Children.RemoveAt(0);

                    arrowLayout.Children[0] = downArrowImage;
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
                            qList.Add(new QuestionText(prompt, placeholder, this));
                            i += 4;
                        }

                        break;
                }
            }
        }

        public void updateString()
        {
            Response = "";

            foreach (Question q in qList)
            {
                Response += q.getResponse();
            }
        }
    }
}
