using System;

namespace Injector.Runtime.Core
{
    public interface IDependenciesInjector : IDisposable
    {
        T Get<T>() where T : class;
        void Register<TInterface, TImplementation>() where TImplementation : class, TInterface;
        void Register<T>(T instance) where T : class;
        void RegisterRawType(Type type, object instance);
        void Register<TClass>() where TClass : class;
        void Clear<T>() where T : class; 
    }
}