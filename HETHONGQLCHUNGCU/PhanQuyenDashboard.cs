using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public class PhanQuyenDashboard
    {      
        public static void bat(params Button[] button)
        {
            foreach(Button btn in button)
                btn.Enabled = true;
        }
        public static void tat(params Button[] button)
        {
            foreach (Button btn in button)
                btn.Enabled = false;
        }
    }
}
