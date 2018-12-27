using System;
using libs;
using Nancy;
using System.Threading;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace huesharp.webServer
{
    public class MainWebServer
    {
        NancyHost nancyHost = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost"));
        public void Start()
        {
            nancyHost.Start();
            Console.WriteLine("Web server running...");
        }
        public void Stop()
        {
            Console.WriteLine("Web server stopping...");
            nancyHost.Stop(); 
        }
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

    }
    
