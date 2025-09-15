using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.MemberData
{
    internal class CompanyRequiredFieldValidation
    {
        public CompanyRequiredFieldValidation(string name, string gST, string pAN, params string[] messages)
        {
            Name = name;
            GST = gST;
            PAN = pAN;
            this.ValidationMessage = new List<string>(messages);
        }

        public string Name { get; set; }
        public string GST { get; set; }
        public string PAN { get; set; }

        public List<string> ValidationMessage { get; set; }
    }
}
