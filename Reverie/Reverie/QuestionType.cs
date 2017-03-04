using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Reverie
{
    class QuestionType : BindableObject
    {
        private int idValue;

        public static readonly BindableProperty IsEnabledProperty =
            BindableProperty.Create("IsEnabled", typeof(bool), typeof(QuestionType), false);
        public bool IsEnabled
        {
            get { return (bool) GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); } 
        }

        public static readonly BindableProperty IsExpandedProperty =
            BindableProperty.Create("IsExpanded", typeof(bool), typeof(QuestionType), false);
        public bool IsExpanded
        {
            get { return (bool) GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); } 
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(String), typeof(QuestionType), "Default Title");
        public String Title
        {
            get { return (String) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); } 
        }

        public QuestionType(String t, int id, bool enabled)
        {
            Title = t;
            idValue = id;
            IsEnabled = enabled;
        }

        public String toString()
        {
            String questionString = "";

            return questionString;
        }

        // When selected, switch whether or not it is expanded
        public void selected()
        {
            IsExpanded = !IsExpanded;
        }
    }
}
