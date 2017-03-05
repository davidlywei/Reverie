using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class AccordionLayout : ListView
    {
        public AccordionLayout()
        {
            ObservableCollection<QuestionType> list = new ObservableCollection<QuestionType>();

            for (int i = 0; i < 10; i++)
                list.Add(new QuestionType(toString("Question #" + i, true, i)));

            // Set template for items
            ItemTemplate = new DataTemplate(typeof(QuestionCell));

            // Add items to ItemSource
            ItemsSource = list;

            HasUnevenRows = true;

            // Add selection listner
            ItemTapped += OnSelection;
        }

        public String toString(String Title, bool IsEnabled, int idValue)
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



        void OnSelection(object s, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            else
            {
                ((QuestionType)e.Item).selected();
            }

            ((ListView)s).SelectedItem = null;
        }
    }
}
