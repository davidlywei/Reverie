using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class QuestionText : Question
    {
        private String prompt;
        private Entry entry;
        private String placeholder;

        public QuestionText(String p, String h, QuestionCell q)
        {
            // Store prompt and placeholder
            prompt = p;
            placeholder = h;

            entry = new Entry()
            {
                Placeholder = placeholder,
            };

            // update String
            entry.TextChanged += (o, s) => { q.updateString(); };
        }

        public Grid getLayout()
        {
            // Sets the layout fo the text
            StackLayout textLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =  {
                                new Label ()
                                {
                                    HorizontalTextAlignment = TextAlignment.Center,
                                    Text = prompt
                                },
                                entry
                            }
            };

            // Stores Questions in grid to get consistent formatting across screen sizes
            // and orientations 
            Frame questionFrame = new Frame()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = ReverieUtils.QUESTION_LAYOUT_THICKNESS,
                Content = textLayout
            };

            Grid questionGrid = new Grid();
            questionGrid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(1, GridUnitType.Star)
                    });
            questionGrid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = new GridLength(ReverieUtils.QUESTION_LAYOUT_RATIO, GridUnitType.Star)
                    });

            questionGrid.Children.Add(questionFrame, 1, 0);

            return questionGrid;
        }

        // return response
        public String getResponse()
        {
            return entry.Text;
        }

        // return prompt
        public String getPrompt()
        {
            return prompt;
        }

        // not used
        public String toString()
        {
            return " { 'Type': '" + ReverieUtils.QUESTION_TEXT + "', 'Prompt': '" + prompt + "', 'Placeholder': '" + placeholder + "'}";
        }
    }
}
