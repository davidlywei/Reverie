using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Security; //apparently not PCL compliant, must use in iOS or Android

namespace Reverie
{
	public interface Password
    {
		String GetHash();
    }
}
