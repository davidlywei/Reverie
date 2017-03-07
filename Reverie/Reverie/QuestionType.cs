using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Reverie
{
    public class QuestionType : BindableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int idValue;

        // Values to bind to
        private bool isEnabled;
        public bool IsEnabled
        {
            set
            {
                Application.Current.Properties[Title] = value;
                setValue(ref isEnabled, value);
            }
            get { return isEnabled; }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            set { setValue(ref isExpanded, value); }
            get { return isExpanded; }
        }

        private String title;
        public String Title
        {
            set { setValue(ref title, value); }
            get { return title; }
        }

        private String childrenJSON;
        public String ChildrenJSON
        {
            set { setValue(ref childrenJSON, value); }
            get { return childrenJSON; }
        }

        private String response;
        public String ResponseQT
        {
            set { setValue(ref response, value); }
            get { return response; }
        }
        
        public QuestionType(String s)
        {
            parseString(s);

            IsExpanded = false;
        }

        public void parseString(String input)
        {
            // remove string for children
            ChildrenJSON = input.Substring(input.IndexOf(ReverieUtils.JSON_TAG_QLIST));

            String[] words = input.Split(ReverieUtils.DELIMITERS);

            // Remove empty strings
            words = words.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            Application app = Application.Current;

            // Parse JSON
            for(int i = 0; i < words.Length; i++)
            {
                switch (words[i])
                {
                    case ReverieUtils.JSON_TAG_TITLE:
                        Title = words[++i];
                        break;
                    case ReverieUtils.JSON_TAG_ENABLE:
                        if (!app.Properties.ContainsKey(Title))
                        {
                            IsEnabled = Convert.ToBoolean(words[++i]);
                            app.Properties[Title] = IsEnabled;
                        }
                        else
                        {
                            IsEnabled = (bool)app.Properties[Title];
                        }
                        break;
                     case ReverieUtils.JSON_TAG_ID:
                        idValue = Convert.ToInt32(words[++i]);
                        break;
                 }
            }
        }

        public String toString()
        {
            String questionString = "{";

            questionString += "\"" + ReverieUtils.JSON_TAG_TITLE + "\":\"";
            questionString += Title + "\",";
            questionString += "\"" + ReverieUtils.JSON_TAG_ENABLE + "\":\"";
            questionString += (IsEnabled ? Boolean.TrueString : Boolean.FalseString) + "\",";
            questionString += "\"" + ReverieUtils.JSON_TAG_ID + "\":\"";
            questionString += idValue + "\",";
            questionString += "\"" + ReverieUtils.JSON_TAG_QLIST + "\":[]}";

            return questionString;
        }

        // When selected, switch whether or not it is expanded
        public void selected()
        {
            IsExpanded = !IsExpanded;
        }

        // generalized set value handler
        void setValue<T>(ref T variable, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Object.Equals(variable, value))
            {
                variable = value;
                OnPropertyChanged(propertyName);
            }
        }

        // OnProperty changed notifier
        protected virtual void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        // Return responses gathered from questions
        public String getResponse()
        {
            return ResponseQT;
        }
    }
}
