using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.Model.Company
{
    internal class CompanyResult
    {
        public CompanyDtoTest Payload { get; set; }
        public ValidationErrorResponse Response { get; set; }
    }
}
