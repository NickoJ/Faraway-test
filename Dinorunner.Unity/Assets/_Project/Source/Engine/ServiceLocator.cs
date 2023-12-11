using System;
using System.Collections.Generic;

namespace NickoJ.DinoRunner.Engine
{
    /// <summary>
    /// Implementation of service locator.
    /// </summary>
    internal sealed class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> _dictionary = new();

        public T Get<T>()
        {
            return (T)_dictionary[typeof(T)];
        }

        /// <summary>
        /// Register in the locator an instance of type.
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        internal void Register<T>(T instance)
        {
            _dictionary[typeof(T)] = instance;
        }
    }
}