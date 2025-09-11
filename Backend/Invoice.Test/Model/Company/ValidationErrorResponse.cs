using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.Model.Company
{
    public class ValidationErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (!(obj is ValidationErrorResponse)) return false;

            if (this == obj) return true;

            ValidationErrorResponse res = obj as ValidationErrorResponse;

            if (Errors.Count != res.Errors.Count) return false;

            bool isSummaryMatch = Type == res.Type && Title == res.Title && Status == res.Status;

            foreach (var error in Errors)
            {
                List<string> errorMessage = new List<string>();
                bool isKeyExist = res.Errors.TryGetValue(error.Key, out errorMessage);

                if (!isKeyExist) return false;

                if (error.Value.Count != errorMessage.Count) return false;

                for (int index = 0; index < error.Value.Count; index++)
                {
                    if (error.Value[index] != errorMessage[index]) return false;
                }
            }

            return true;
        }
    }
}
