using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Signaler.Library.Services
{
    public enum ServiceHostType
    {
        Web,
        Mobile,
        Remote
    }

    public enum ServiceTargetType
    {
       Business,
       Core
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServiceHost : Attribute
    {
        public ServiceHost(ServiceHostType _type)
        {
            Type = _type;
        }

        public ServiceHostType Type { get; set; }
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServiceTarget : Attribute
    {
        public ServiceTarget(ServiceTargetType _target)
        {
            Target = _target;
        }

        public ServiceTargetType Target { get; set; }
    }
}
