using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Sockets
{
    public static class RootController
    {
        public static byte[] BadRequest()
        {
            return Encoding.ASCII.GetBytes(@"HTTP/1.1 404 Not Found\r\n\r\n");
        }
        
        [Route("/hello.html")]
        public static byte[] HelloHtml(string response)
        {
            return ResponseBuilder.GetHtmlResponse(File.ReadAllBytes("hello.html"));
        }
        
        [Route("/groot.gif")]
        public static byte[] GrootGif(string response)
        {
            return ResponseBuilder.GetHtmlResponse(File.ReadAllBytes("groot.gif"));
        }
        
        [Route("/time.html")]
        public static byte[] TimeHtml(string response)
        {
            var file = File.ReadAllText("time.template.html");
            file = file.Replace("{{ServerTime}}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
            return ResponseBuilder.GetHtmlResponse(Encoding.ASCII.GetBytes(file));
        }
    }
}