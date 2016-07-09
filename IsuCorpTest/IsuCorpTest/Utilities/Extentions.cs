using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsuCorpTest.Utilities
{
    public static class Extentions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, int page, int records, out long total)
        {
            total = queryable.Count();
            return queryable.Skip((page - 1) * records).Take(records);
        }

        public static IList<T> GetPage<T>(this IList<T> list, int page, int records, out int total)
        {
            total = list.Count();
            return list.Skip((page - 1) * records).Take(records).ToList();
        }

        public static Type GetPropertyDeclaringType(this Type intance, string property)
        {
            if (intance.GetProperty(property) == null)
            {
                return null;
            }

            var propertyInfo = intance.GetProperty(property);

            return propertyInfo.DeclaringType;
        }
    }
}
