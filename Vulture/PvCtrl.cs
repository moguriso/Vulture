using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Vulture
{
    public class PvCtrl
    {
        public PvCtrl()
        {
            Debug.WriteLine("PvCtrl Construct");
        }

        ~PvCtrl()
        {
            Debug.WriteLine("PvCtrl Construct");
        }

        public void testFunction()
        {
            Debug.WriteLine("called");
        }

    }
}
