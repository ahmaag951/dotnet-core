using LinqKit;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Common.Infrastructure
{
    public static class Helper
    {
        public static Expression<Func<T, bool>> GetPredicate<T, TDto>(TDto dto)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var predicate = PredicateBuilder.New<T>(true);
            var properities = typeof(TDto).GetProperties().Select(x => new { type = x.PropertyType, property = x.Name, value = x.GetValue(dto) }).Where(x => x.value != null).ToList();
            foreach (var filter in properities)
            {
                if (!PropertyExists(filter.property, typeof(T)) || filter.type == typeof(Guid?[])) continue;

                var member = Expression.Property(param, filter.property);

                var constant = GetValueExpression(filter.property, filter.value, param);

                if (filter.type == typeof(string) && string.IsNullOrWhiteSpace(filter.value.ToString())) continue;
                if (filter.type == typeof(DateTime?))
                {
                    Expression left = Expression.Property(param, filter.property);
                    var dayDate = ((DateTime?)filter.value).Value.Date;
                    Expression right1 = Expression.Constant(dayDate);
                    //
                    if (properities.Count(q => q.type == typeof(DateTime?)) == 2)
                    {
                        var condition1 = filter.property.ToLower().Contains("enddate") ? Expression.LessThanOrEqual(left, right1) : Expression.GreaterThanOrEqual(left, right1);
                        predicate.And(Expression.Lambda<Func<T, bool>>(condition1, param));
                    }
                    else
                    {
                        var condition1 = Expression.GreaterThanOrEqual(left, right1);
                        predicate.And(Expression.Lambda<Func<T, bool>>(condition1, param));
                        predicate.And(Expression.Lambda<Func<T, bool>>(condition1, param));
                        var dayAfter = ((DateTime?)filter.value).Value.Date.AddDays(1);
                        Expression right2 = Expression.Constant(dayAfter);
                        var condition2 = Expression.LessThan(left, right2);
                        predicate.And(Expression.Lambda<Func<T, bool>>(condition2, param));
                    }
                    continue;
                }
                var lambda = filter.type == typeof(string) ?
                     predicate.And(Expression.Lambda<Func<T, bool>>(member.StartWith(constant), param))
                      :
                     predicate.And(Expression.Lambda<Func<T, bool>>(Expression.Equal(member, constant), param));

            }
            return predicate;
        }

        private static bool PropertyExists(string prop, Type t)
        {

            var propInfo = t.GetMember(prop)
                .Where(p => p is PropertyInfo)
                .Cast<PropertyInfo>()
                .FirstOrDefault();

            if (propInfo != null)
            {
                t = propInfo.PropertyType;

                if (t.GetInterfaces().Contains(typeof(IEnumerable)) && t != typeof(string))
                {
                    t = t.IsGenericType ? t.GetGenericArguments()[0] : t.GetElementType();

                }
            }
            else
            {
                return false;
            }
            return true;
        }
        private static UnaryExpression GetValueExpression(string propertyName, object val, ParameterExpression param)
        {

            var member = Expression.Property(param, propertyName);
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType);

            if (!converter.CanConvertFrom(typeof(string)))
                throw new NotSupportedException();

            var constant = Expression.Constant(val);
            return Expression.Convert(constant, propertyType);
        }
    }
}
