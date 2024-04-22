using System.Linq.Expressions;

namespace HotelManagementSystem.Library.Generic
{
    public static class Generic
    {
        public static Expression<Func<T, bool>> CombineConditions<T>(List<Expression<Func<T, bool>>> conditions)
        {
            var param = Expression.Parameter(typeof(T), "x");
            Expression body = null;

            foreach (var condition in conditions)
            {
                body = body == null ? Expression.Invoke(condition, param) : Expression.AndAlso(body, Expression.Invoke(condition, param));
            }

            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}