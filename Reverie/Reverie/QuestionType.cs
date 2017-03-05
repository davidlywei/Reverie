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
    class QuestionType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int idValue;

        private bool isEnabled;
        public bool IsEnabled
        {
            set { setValue(ref isEnabled, value); }
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

        public QuestionType(String s)
        {
            parseString(s);

            IsExpanded = false;
        }

        public void parseString(String input)
        {
            char[] delimiters = { '{', '\"', ':', ',', '[', ']', '}' };
            String[] words = input.Split(delimiters);

            // Remove empty strings
            words = words.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            for(int i = 0; i < words.Length; i++)
            {
                switch (words[i])
                {
                    case ReverieUtils.JSON_TAG_TITLE:
                        Title = words[++i];
                        break;
                    case ReverieUtils.JSON_TAG_ENABLE:
                        IsEnabled = Convert.ToBoolean(words[++i]);
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

        void setValue<T>(ref T variable, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Object.Equals(variable, value))
            {
                variable = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected virtual void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
