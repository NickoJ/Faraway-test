using System;
using System.Collections.Generic;

namespace NickoJ.DinoRunner.Engine
{
    internal sealed class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> _dictionary = new();

        public ServiceLocator()
        {
            
        }

        public T Get<T>()
        {
            return (T)_dictionary[typeof(T)];
        }

        internal void Register<T>(T instance)
        {
            _dictionary[typeof(T)] = instance;
        }
    }
}