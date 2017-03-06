using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    interface Question
    {
        Grid getLayout();
        String getResponse();
        String toString();
    }
}
