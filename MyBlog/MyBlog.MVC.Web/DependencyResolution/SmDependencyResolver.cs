using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyBlog.Core.Infrastructure.Logging;
using StructureMap;

namespace MyBlog.MVC.Web.DependencyResolution
{
    public class SmDependencyResolver : IDependencyResolver
    {

        private readonly IContainer _container;

        public SmDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null) return null;
            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                         ? _container.TryGetInstance(serviceType)
                         : _container.GetInstance(serviceType);
            }
            catch (StructureMapException ex)
            {
                LogUtility.Log.Error(ex);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }
    }
}