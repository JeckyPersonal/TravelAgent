using Invoice.Test.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Exceptions
{
    internal class ValidationException : Exception
    {
        private readonly ValidationErrorResponse _validationError;

        public ValidationErrorResponse Errors { get => _validationError; }

        public ValidationException(ValidationErrorResponse response)
        {
            this._validationError = response;
        }
    }
}
