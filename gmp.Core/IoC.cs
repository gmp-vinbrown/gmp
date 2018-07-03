using System;
using System.Collections.Generic;

namespace gmp.Core
{
    public static class IoC
    {
        public static Func<Type, object> GetService;
        public static Func<Type, IEnumerable<Object>> GetServices;
    }
}
