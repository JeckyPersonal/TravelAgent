using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.CustomControl
{
    public partial class Heading : UserControl
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private string _heading;
        public Heading()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return _heading;
            }
            set
            {
                _heading = value;
                label1.Text = value;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void tblLayout_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
