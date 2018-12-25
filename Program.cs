using System;
using CommandLine;
using ConsoleTables;
using libs;
using NLog.Fluent;

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
    
    internal static class Program
    {
        private static void Main(string[] args)
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
                        
                        webServer.MainWebServer.Start();

                    }
                    
                });
            
            logger.Info("EOP");
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