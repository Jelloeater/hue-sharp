using System;
using Nancy;

namespace huesharp.webServer
{
    public static class MainWebServer
    {
        public static void Start()
        {
            var nancyHost = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost"));
            nancyHost.Start();
            Console.WriteLine("Web server running...");

            Console.ReadLine();
            nancyHost.Stop();
        }
    }
    public class Module : NancyModule
    {
        public Module()
        {
            Get("/greet/{name}", x => {
                return string.Concat("Hello ", x.name);
            });
        }
    }}