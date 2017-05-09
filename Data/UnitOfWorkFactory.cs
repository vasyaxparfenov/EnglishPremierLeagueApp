using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public static class UnityOfWorkFactory
    {
        private static readonly Dictionary<string,Type> StringToTypeDictionary = new Dictionary<string, Type>();
        
        public static void Register(string name,Type type)
        {
            if (!typeof(IUnitOfWork).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
            {
                throw new UnitOfWorkException("You can register only types which implements IUnityOfWork interfce");
            }
            StringToTypeDictionary.Add(name, type);            
        }

        public static IUnitOfWork CreateUnityOfWork(string name, DbContext context)
        {
            return (IUnitOfWork) Activator.CreateInstance( StringToTypeDictionary[name], context);
        }
    }
}
