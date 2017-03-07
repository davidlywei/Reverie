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
        
        // Create bindable property to store string to represent children in the layout
        private static readonly BindableProperty ChildrenProperty =
            BindableProperty.Create("Children", typeof(String), typeof(QuestionCell), "Child");
        public String Children
        {
            set { SetValue(ChildrenProperty, value); }
            get { return (String) GetValue(ChildrenProperty); }    
        }
        
        // Create one way to source bindable property to send responses
        private static readonly BindableProperty ResponsePropertyQC =
            BindableProperty.Create("Response", typeof(String), typeof(QuestionCell), "default", BindingMode.OneWayToSource);
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
            // Create images for expansion indicator
            upArrowImage = new Image() { Source = ImageSource.FromResource(ReverieUtils.UP_ICON) };
            downArrowImage = new Image() { Source = ImageSource.FromResource(ReverieUtils.DOWN_ICON) };

            qList = new List<Question>();

            // Create dictionary to filter out multiple adds
            questionHistory = new Dictionary<string, string>();

            // Set bindings
            this.SetBinding(ChildrenProperty, "ChildrenJSON");
            this.PropertyChanged += childrenPropertyChangeHandler;

            this.SetBinding(ResponsePropertyQC, "ResponseQT");

            // Create layout for children items
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

            // Change cellview height manually for iOS
			//this.Height = 65;//(double) cellView.Height;
			//this.Height = 100;//(double) cellView.Height;

            View = cellView;
        }

        private Frame createTitle()
        {
            // Create title label, set bindings
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
                // reducing spacing as much as possible
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
            // If enabled add items to childrenLayout
            // if not, remove
            if (childrenLayout.IsEnabled != isExpanded)
            {
                isExpanded = childrenLayout.IsEnabled;

				int numCells = 0;

                if (isExpanded)
                {
                    foreach (Question q in qList)
                    {
						numCells++;

                        childrenLayout.Children.Add(q.getLayout());
                    }

					//this.Height = 65 * numCells;
					//this.Height = 260;
                   
                    arrowLayout.Children[0] = upArrowImage;
                }
                else
                {
                    int numChildren = childrenLayout.Children.Count;

                    for (int i = 0; i < numChildren; i++)
                        childrenLayout.Children.RemoveAt(0);
					
					//this.Height = 65;

                    arrowLayout.Children[0] = downArrowImage;
                }
            }
        }

        private void childrenPropertyChangeHandler(object s, EventArgs e)
        {
            // Convert string to children
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
                    // Look for Text Question tag, grab values
                    case ReverieUtils.QUESTION_TEXT:
                        String prompt = words[i + 2];
                        String placeholder = words[i + 4];

                        // Check if question is repeated
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

        // Return string responses
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
