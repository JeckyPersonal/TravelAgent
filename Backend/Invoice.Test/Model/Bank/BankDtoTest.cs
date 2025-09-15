namespace Invoice.Test.Model.Bank
{
    public class BankDtoTest : Invoice.DTO.BankDto
    {
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;

            if(this == obj) return true;

            if(!(obj is Invoice.DTO.BankDto)) return false;

            Invoice.DTO.BankDto bank = (Invoice.DTO.BankDto)obj;

            return this.Id == bank.Id && this.BankName == bank.BankName;
        }
    }
}
