using System;

namespace Sockets
{
    public class RouteAttribute : Attribute
    {
        public readonly string routing;

        public RouteAttribute(string routing)
        {
            this.routing = routing;
        }
    }
}