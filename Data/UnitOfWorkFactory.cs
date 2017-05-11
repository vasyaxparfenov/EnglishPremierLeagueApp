using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public static class UnityOfWorkFactory
    {
        private static readonly Dictionary<string,Type> StringToTypeDictionary = new Dictionary<string, Type>();
        
        /// <summary>
        /// Registers certain type of IUnitOfWork implementation based on name 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public static void Register(string name,Type type)
        {
            if (!typeof(IUnitOfWork).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
            {
                throw new UnitOfWorkFactoryException("You can register only types which implements IUnityOfWork interfce");
            }
            StringToTypeDictionary.Add(name, type);            
        }
        /// <summary>
        /// Generic registration of IUnitOfWork implementation type based on name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public static void Register<T>(string name)
        {
            if (!typeof(IUnitOfWork).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                throw new UnitOfWorkFactoryException("You can register only types which implements IUnityOfWork interfce");
            }
            StringToTypeDictionary.Add(name, typeof(T));
        }
        /// <summary>
        /// Returns IUnitOfWork implementation of certain type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IUnitOfWork CreateUnitOfWork(string name, DbContext context)
        {
            if (!StringToTypeDictionary.ContainsKey(name))
            {
                throw new UnitOfWorkFactoryException($"{name} type isn't registered in UnitOfWorkFactory");
            }
            return (IUnitOfWork) Activator.CreateInstance( StringToTypeDictionary[name], context);
        }
    }
}
