using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public static class RepositoryFactory
    {
        private static readonly Dictionary<Type, Type> AbstractionToImplementationDictionary = new Dictionary<Type, Type>();
        /// <summary>
        /// Registers an implementation of certain abstraction to RepositoryFactory 
        /// </summary>
        /// <param name="abstractionType"></param>
        /// <param name="implementationType"></param>
        public static void Register(Type abstractionType, Type implementationType)
        {

            if (!typeof(IRepository<>).MakeGenericType(implementationType.GenericTypeArguments[0]).GetTypeInfo().IsAssignableFrom(abstractionType.GetTypeInfo()))
            {
                throw new RepositoryFactoryException("Abstraction type should be either IRepository<> or assignable from it");
            }
            if (!abstractionType.GetTypeInfo().IsAssignableFrom(implementationType.GetTypeInfo()))
            {
                throw new RepositoryFactoryException("Implementation type should be assignable from abstraction type");
            }
            AbstractionToImplementationDictionary.Add(abstractionType, implementationType);
        }
        /// <summary>
        /// Generic registration of certain abstraction implementation to RepositoryFactory
        /// </summary>
        /// <typeparam name="TAbstraction"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        public static void Register<TAbstraction, TImplementation>()
        {
            Register(typeof(TAbstraction), typeof(TImplementation));
        }
        /// <summary>
        /// Returns an registered implementation of abstraction
        /// </summary>
        /// <param name="typeToGet"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static object CreateRepository(Type typeToGet, DbContext context)
        {

            if (!AbstractionToImplementationDictionary.ContainsKey(typeToGet))
            {
                throw new RepositoryFactoryException($"{typeToGet} isn't registered in RepositoryFactory");
            }
            return Activator.CreateInstance(AbstractionToImplementationDictionary[typeToGet], context);
        }
        /// <summary>
        /// Returns an registered implementation of abstraction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static T CreateRepository<T>(DbContext context)
        {
            return (T) CreateRepository(typeof(T), context);
        }
    }
}
