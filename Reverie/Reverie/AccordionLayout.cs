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
                list.Add(new QuestionType("Question #" + i, i, true));

            // Set template for items
            ItemTemplate = new DataTemplate(typeof(QuestionCell));

            // Add items to ItemSource
            ItemsSource = list;

            HasUnevenRows = true;

            // Add selection listner
            ItemTapped += OnSelection;
        }

        void OnSelection(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            else
            {
                ((QuestionType)e.Item).selected();
            }
        }
    }
}
