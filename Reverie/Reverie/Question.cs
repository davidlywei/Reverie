using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    // Interface to tie together different Question formats
    public interface Question
    {
        // Gets layout for each question
        Grid getLayout();

        // Gets the string response from the question
        String getResponse();

        // not used
        String toString();
    }
}
