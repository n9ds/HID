using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HID_PDF.Forms
{
    public class SetlistItemComparer : IEqualityComparer<ListViewItem>
    {
        bool IEqualityComparer<ListViewItem>.Equals(ListViewItem x, ListViewItem y)
        {
            return ((x.Text == y.Text) && (x.Index == y.Index));
        }

        int IEqualityComparer<ListViewItem>.GetHashCode(ListViewItem obj)
        {
            if (obj is null)
                return 0;
            return obj.Text.GetHashCode();
        }
    }
}
