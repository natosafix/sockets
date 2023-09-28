using System;
using System.Text;

namespace Sockets
{
    public static class ResponseBuilder
    {
        private static string GetHtmlHead(int length) =>
            $"HTTP/1.1 200 OK\r\nContent-Type: text/html; charset=utf-8\r\nContent-Length: {length}\r\n\r\n";
        
        private static string GetGifHead(int length) =>
            $"HTTP/1.1 200 OK\r\nContent-Type: image/gif; charset=utf-8\r\nContent-Length: {length}\r\n\r\n";
        
        public static byte[] GetHtmlResponse(byte[] body)
        {
            var headBytes = Encoding.ASCII.GetBytes(GetHtmlHead(body.Length));
            var responseBytes = new byte[headBytes.Length + body.Length];
            Array.Copy(headBytes, responseBytes, headBytes.Length);
            Array.Copy(body, 0,
                responseBytes, headBytes.Length,
                body.Length);
            return responseBytes;
        }
        
        public static byte[] GetGifResponse(byte[] body)
        {
            var headBytes = Encoding.ASCII.GetBytes(GetHtmlHead(body.Length));
            var responseBytes = new byte[headBytes.Length + body.Length];
            Array.Copy(headBytes, responseBytes, headBytes.Length);
            Array.Copy(body, 0,
                responseBytes, headBytes.Length,
                body.Length);
            return responseBytes;
        }
    }
}