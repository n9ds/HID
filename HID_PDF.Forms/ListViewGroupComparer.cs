using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HID_PDF.Forms
{
    public class ListViewGroupComparer : IComparer<ListViewGroup>
    {
        public int Compare(ListViewGroup objA, ListViewGroup objB)
        {
            return (objA.Header.CompareTo(objB.Header));
        }
    }
}
