using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HID_PDF.Infrastructure
{

    public class Validation : IValidation
    {
        public IDictionary<String, String> Errors { get; set; }

        public Validation()
        {
            Errors = new Dictionary<String, String>();
        }
        
        public bool ValidateForm(Form form, IEnumerable<String> Fields)
        {
            bool IsFormValid = true;
            foreach (var Field in Fields)
            {
                Control Control = form.Controls.Find(Field, true).FirstOrDefault();
                if (Control is TextBox)
                {
                    IsFormValid &= ValidateSongTextField(Control);
                }
                if (Control is ListBox)
                {
                    IsFormValid &= ValidateSongListBox(Control);
                }
            }
            return (IsFormValid);
        }

        private bool ValidateSongTextField(Control TextField)
        {
            if (TextField == null)
            {
                throw (new NotImplementedException("Validation Error: Field " + TextField.Name + " does not exist.\n"));
            }
            if (!String.IsNullOrEmpty(((TextBox)TextField).Text))
            {
                TextField.BackColor = Color.Empty;
                Errors.Remove(TextField.Name);
                return true;
            }
            else
            { 
                TextField.BackColor = Color.Red;
                if (!Errors.ContainsKey(TextField.Name))
                {
                    Errors.Add(TextField.Name, "Cannot be blank");
                }
                return false;
            }
        }

        private bool ValidateSongListBox(Control Listbox)
        {
            if (Listbox == null)
            {
                throw (new NotImplementedException("Validation  Error: Field " + Listbox.Name + " does not exist.\n"));
            }
            if (((ListBox)Listbox).SelectedItems.Count > 0)
            {
                Listbox.BackColor = Color.Empty;
                Errors.Remove(Listbox.Name);
                return true;
            }
            else
            {
                Listbox.BackColor = Color.Red;
                Errors.Add(Listbox.Name, "Select an item");
                return false;
            }
        }

        public void ShowErrors()
        {
           // MessageBox.Show("Oops: ");
            var ErrorDlg = new ErrorDialog();
            var ErrorSeq = 1;
            var ControlHeight = 25;
            var ControlX = 25;
            var ControlY = 50;
            var LabelName = "Error";
            foreach (var errorMsg in Errors)
            {
                var L = new Label();
                L.Name = LabelName + ErrorSeq.ToString();
                L.Height = 25;
                L.Width = ErrorDlg.Width - 50;
                L.Location = new Point(ControlX, ControlY);
                L.Text = "Error: Field " + errorMsg.Key + " " + errorMsg.Value;
                L.Visible = true;
                ErrorDlg.Controls.Add(L);
                ControlY += ControlHeight;
                ErrorSeq++;
            }
            ErrorDlg.Show();
        }
    }
}
