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

        public QuestionType(String t, int id, bool enabled)
        {
            Title = t;
            idValue = id;
            IsEnabled = enabled;
            IsExpanded = false;
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

            Title = "Selected now";
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
