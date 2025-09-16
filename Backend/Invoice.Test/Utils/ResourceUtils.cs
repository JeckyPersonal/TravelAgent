using Invoice.Test.Model.Company;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.Utils
{
    internal class ResourceUtils
    {
        public T readAndDeserializeFileFile<T>(string resourceName)
        {
            string json = this.readFile(resourceName);

            return JsonConvert.DeserializeObject<T>(json); //serializer.Deserialize(reader, typeof(List<Company>));
        }

        public ValidationErrorResponse GetErrorObject(string resourceName,  string fieldName, string message, HttpStatusCode statusCode)
        {
            string resourceContent = this.readFile(resourceName);

            resourceContent = resourceContent.Replace("<<StatusCode>>", ((int)statusCode).ToString())
                .Replace("<<ErrorMessage>>", message)
                .Replace("<<FieldName>>", fieldName);

            return JsonConvert.DeserializeObject<ValidationErrorResponse>(resourceContent);

        }

        public string readFile(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");

            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();

        }
    }
}
