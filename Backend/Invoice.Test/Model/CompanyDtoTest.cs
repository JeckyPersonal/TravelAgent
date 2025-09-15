using Castle.Components.DictionaryAdapter.Xml;
using Invoice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.Model
{
    internal class CompanyDtoTest : CompanyDto
    {
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (this==obj)
                return true;

            if (!(obj is CompanyDto))
                return false;

            CompanyDto comp = (CompanyDto)obj;

            return (this.PANNo == comp.PANNo)
                && this.PhoneNumber == comp.PhoneNumber
                && this.Country==comp.Country
                && this.Address1 == comp.Address1
                && this.Address2==comp.Address2
                && this.Address3 == comp.Address3            
                && this.City == comp.City
                && this.State == comp.State;
        }

        public CompanyDto Clone()
        {
            return new CompanyDto()
            {
                PANNo = this.PANNo,
                PhoneNumber = this.PhoneNumber,
                Country = this.Country,
                Address1 = this.Address1,
                Address2 = this.Address2,
                Address3 = this.Address3,
                City = this.City,
                State = this.State,
                GSTNo = this.GSTNo,
                Name = this.Name,
                Zip = this.Zip,
            };
        }
    }
}
