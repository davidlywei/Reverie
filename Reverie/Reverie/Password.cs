using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class Password : ContentPage
    {
        ViewController view;

        public Password(ViewController v)
        {
            view = v;

            String responses = view.getResponse();

            Content = new StackLayout()
            {
                Children =
                {
                    new Label() { Text = "Responses = "},
                    new Label() { Text = responses }
                }
            };
        }
    }
}
