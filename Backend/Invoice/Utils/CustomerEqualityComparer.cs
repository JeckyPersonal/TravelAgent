using Invoice.Model;
using System.Diagnostics.CodeAnalysis;

namespace Invoice.Utils
{
    public class CustomerEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer? x, Customer? y)
        {
            if (x == null && y == null) return true;

            if (x == null || y == null) return false;

            return x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] Customer obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
