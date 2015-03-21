using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearn.Utils
{
    public static class PropertyUtils
    {
        public static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
