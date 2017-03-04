using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class Questionnaire
    {
        public Questionnaire()
        { }

        public StackLayout getLayout()
        {
            StackLayout qLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    // Menu
                    new Label() { Text = "Questionnaire!!"},
                    // AccordionLayout
                    new AccordionLayout () { }
                }
            };

            return qLayout;
        }
    }
}
