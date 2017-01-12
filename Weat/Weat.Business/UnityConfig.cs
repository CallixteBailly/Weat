using Microsoft.Practices.Unity;
using System;

namespace Weat.Business
{
    public class UnityConfig
    {
        public static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            UnityContainer container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });
        public static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterType<IManagerData, ManagerData>(new TransientLifetimeManager());
        }
        public static T Resolve<T>()
        {
            return container.Value.Resolve<T>();
        }
    }
}
