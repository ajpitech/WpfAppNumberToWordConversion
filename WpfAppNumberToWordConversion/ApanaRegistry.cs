using System;
using System.Collections.Generic;

namespace WpfAppNumberToWordConversion
{
    public class ApanaRegistry
    {
        static Dictionary<Type,object> Registry = new Dictionary<Type,object>();

        public static void Register<T>(T instance)
        {
             Registry.Add(typeof(T), instance);
        }
        public static T GetInstance<T>()
        {
            return (T)Registry[typeof(T)];
        }
       

    }
}