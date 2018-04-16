using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatchLibrary
{
    public static class Matcher
    {
        public static T Match<T>(this object entity) where T : class, new()
        {
            T returnObj = new T();

            foreach (var sourceProp in entity.GetType().GetProperties())
            {
                var property = returnObj.GetType().GetProperties().Where(x => x.Name == sourceProp.Name).SingleOrDefault();

                if (property == null)
                    continue;

                var name = sourceProp.Name;
                var value = sourceProp.GetValue(entity);

                foreach (var item in property.GetCustomAttributes(true))
                {
                    if (item is Match)
                    {
                        MethodInfo methodInfo = typeof(Matcher).GetMethod("Match");
                        MethodInfo genericMethod = methodInfo.MakeGenericMethod(Type.GetType(property.PropertyType.FullName));
                        value = genericMethod.Invoke(value, new object[] { value });
                    }
                }

                if (property.PropertyType.FullName == value.GetType().FullName)
                    returnObj.GetType().GetProperty(name).SetValue(returnObj, value);
            }

            return returnObj;
        }
    }
}
