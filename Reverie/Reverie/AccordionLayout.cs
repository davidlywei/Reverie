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
    public class AccordionLayout : ListView
    {
        public AccordionLayout()
        {
            // Add selection listner
            ItemTapped += OnSelection;
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
