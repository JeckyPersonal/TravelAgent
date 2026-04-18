using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI
{
    internal class Settings
    {
        //public static string BaseUrl => "http://localhost:5025";

        public static string BaseUrl { get; internal set; }
        public static int CompanyId { get; internal set; }
        public static int FinancialYearId { get; internal set; }
        public static string AppData { get; internal set; }
        public static string CompanyName { get; internal set; }
        public static string DateFormat { get; internal set; }

        public static Size getScreenRelativeSize(Form form)
        {
            //var screen = Screen.PrimaryScreen.WorkingArea;
            //return new System.Drawing.Size((int)(screen.Width * 0.8), (int)(screen.Height * 0.8));



            var screen = Screen.PrimaryScreen.WorkingArea;

            int width = (int)(screen.Width * 0.8);
            int height = (int)(screen.Height * 0.8);

            // Adjust for non-client area (borders + title bar)
            int borderWidth = form.Width - form.ClientSize.Width;
            int borderHeight = form.Height - form.ClientSize.Height;

            return new Size(width - borderWidth, height - borderHeight);
        }
    }
}
