using System.Linq.Expressions;

namespace Invoice.Utils
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() => x => true;

        public static Expression<Func<T, bool>> And<T>(
       this Expression<Func<T, bool>> left,
       Expression<Func<T, bool>> right)
        {
            var parameter = left.Parameters[0];

            var rightBody = new ParameterReplacer(
                right.Parameters[0], parameter)
                .Visit(right.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(left.Body, rightBody!), parameter);
        }
    }
}
