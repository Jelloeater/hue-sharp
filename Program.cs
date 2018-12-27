using System;
using System.Threading;
using CommandLine;
using ConsoleTables;
using huesharp.webServer;
using libs;

namespace huesharp
{
    public class Options
    {
        [Option('w', "startWeb", Required = false, HelpText = "Start micro web GUI.")]
        public bool StartWeb { get; set; }
        [Option('l', "printLightList", Required = false, HelpText = "Prints list of lights.")]
        public bool PrintLights { get; set; }
        [Option('o', "turnOnLight", Required = false, HelpText = "Turn on single light.")]
        public int TurnOnLight { get; set; }     
        [Option('f', "turnOffLight", Required = false, HelpText = "Turn off single light.")]
        public int TurnOffLight { get; set; }

    }
    
    public static class Program
    {
        private static readonly AutoResetEvent Closing = new AutoResetEvent(false);
        private static readonly MainWebServer WebServ = new MainWebServer();
        
        public static void Main(string[] args)
        {
            var logger = Logging.GetLogger();

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    if (o.PrintLights)
                    {
                        PrintTable();
                    }

                    if (o.TurnOnLight != 0)
                    {
                        var l = new Light(idIn:o.TurnOnLight,stateIn:false,nameIn:"");
                        l.TurnOn();
                    }
                    
                    if (o.TurnOffLight != 0)
                    {
                        var l = new Light(idIn:o.TurnOffLight,stateIn:true,nameIn:"");
                        l.TurnOff();
                    }
                    
                    if (o.StartWeb)
                    {
                        WebServ.Start();
                        Console.WriteLine("Ctrl+C to Stop");
                        Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit); 
                        Closing.WaitOne();
                        // Blocks thread from ending due to the fact that dotNet treats it as a console app,
                        // and does not respect typical readline for blocking on Linux -_-
                    }  
                });
            
            logger.Info("EOP");
        }
        static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            WebServ.Stop();
            Closing.Set();
        }
        
        private static void PrintTable()
        {
            var lightList = Lights.GetLightList();
            var table = new ConsoleTable("ID","Name", "State");
            
            foreach (Light i in lightList)
            {
                table.AddRow(i.Id,i.Name, i.State);
            }
            table.Write();
            
        }
    }
}