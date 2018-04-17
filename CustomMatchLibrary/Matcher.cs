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
            T targetObj = new T();

            foreach (var sourceProp in entity.GetType().GetProperties())
            {
                PropertyInfo property = GetProperty(targetObj, sourceProp);

                if (property == null)
                    continue;

                var name = property.Name;
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
                    targetObj.GetType().GetProperty(name).SetValue(targetObj, value);
            }

            return targetObj;
        }

        private static PropertyInfo GetProperty(object target, PropertyInfo sourceProp)
        {
            PropertyInfo property = null;

            foreach (var prop in target.GetType().GetProperties())
            {
                if (prop.Name == sourceProp.Name)
                {
                    property = prop;
                    break;
                }
                else
                {
                    foreach (var attribute in prop.GetCustomAttributes(true))
                    {
                        if (attribute is DomainPropertyName dpAtt)
                        {
                            if (dpAtt.Name == sourceProp.Name)
                            {
                                property = prop;
                                break;
                            }
                        }
                    }
                }
            }

            return property;
        }
    }
}
