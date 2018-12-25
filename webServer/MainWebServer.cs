using System;
using libs;
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
            Post("/light/on/{id}", x =>
            {
                var l = new Light(idIn:x.id,stateIn:false,nameIn:"");
                l.TurnOn();
                return HttpStatusCode.OK;
            });
            
            Post("/light/off/{id}", x =>
            {
                var l = new Light(idIn:x.id,stateIn:true,nameIn:"");
                l.TurnOff();
                return HttpStatusCode.OK;
            });
            
            Get("/", x => {
                var lightList = libs.Lights.GetLightList();
                return View["webServer/views/main.html",lightList];
            });
            
            
            
        }
        
    }}