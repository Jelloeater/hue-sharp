using System;
using static EasyHttp.Http.HttpClient;

namespace ConsoleApp2
{
    internal class HttpHelper
    {
        public string GetSiteJson(string siteIn)
        {
            var http = new EasyHttp.Http.HttpClient();
            http.Request.Accept = EasyHttp.Http.HttpContentTypes.ApplicationJson;
            var response = http.Get(siteIn);
            return response.DynamicBody;
        }
    }
    
    internal class Counter
    {
        private int num1;
        private int num2;

        public Counter(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public int Adder()
        {
            
            return this.num1 + this.num2;
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var obj = new ConsoleApp2.Counter(1,2);      
            var z = obj.Adder();
                
            Console.WriteLine("Hello World!" + z);
        }
    }
}
//
//var http = new HttpClient();
//http.Request.Accept = HttpContentTypes.ApplicationJson;
//var response = http.Get("url");
//var customer = response.DynamicBody;
//Console.WriteLine("Name {0}", customer.Name);