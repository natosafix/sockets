using System;
using System.Collections.Generic;
using System.Linq;

namespace Sockets
{
    public static class RequestHandler
    {
        private static readonly Dictionary<string, Func<string, byte[]>> request2Handle = new();
        
        static RequestHandler()
        {
            var methods = typeof(RootController).GetMethods();

            foreach (var currentMethod in methods)
            {
                var attributes = currentMethod.GetCustomAttributes(typeof(RouteAttribute), false);
                var attribute = (RouteAttribute)attributes.FirstOrDefault();
                if (attribute is null)
                    continue;

                Func<string, byte[]> execute = urc => (byte[])currentMethod.Invoke(null, new object[] {urc});

                request2Handle[attribute.routing] = execute;
            }
        }
        
        public static byte[] Process(Request request)
        {
            var urc = request.RequestUri;

            if (request2Handle.TryGetValue(urc, out var handler))
                return handler(urc);
            
            return RootController.BadRequest();
        }
    }
}