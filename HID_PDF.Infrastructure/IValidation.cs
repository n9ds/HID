using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HID_PDF.Infrastructure
{
    interface IValidation
    {
        bool ValidateForm(Form form, IEnumerable<String> Fields);
        void ShowErrors();
    }
}
