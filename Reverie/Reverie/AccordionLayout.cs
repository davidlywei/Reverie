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
                //ItemSelected is called on deselection, which results in SelectedItem being set to null
                return; 
            }
            else
            {
                // Notify that the question has been selected
                ((QuestionType)e.Item).selected();
            }
            
            // Unhighlight the item
            ((ListView)s).SelectedItem = null;
        }
    }
}
