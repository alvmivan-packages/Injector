using System;
using System.Collections.Generic;

namespace Injector.Runtime
{
    public class TypesTool
    {
        public static Type[] ClassesBetween(Type bottomClass, Type topClass)
        {
            if (!topClass.IsClass) throw new Exception($"{topClass} is not a class");
            if (!bottomClass.IsClass) throw new Exception($"{bottomClass} is not a class");

            var types = new List<Type>();
            var currentType = bottomClass;

            while (currentType != topClass && currentType != null)
            {
                types.Add(currentType);
                currentType = currentType.BaseType;
            }

            if (currentType == null || currentType != topClass)
            {
                throw new Exception($"Can't find {topClass} in inheritance chain of {bottomClass}");
            }

            if (currentType == topClass)
            {
                return types.ToArray();
            }

            throw new Exception($"Unknown error in {nameof(ClassesBetween)}");
        }
    }
}