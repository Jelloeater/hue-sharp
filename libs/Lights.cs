using System.Collections.Generic;
using System.Dynamic;
using EasyHttp.Http;

namespace libs
{
    internal static class HttpHelper
    {
        public static dynamic GetSiteJson(string siteIn)
        {
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            var response = http.Get(siteIn);
            return response.DynamicBody;
        }
    }

    public class Light
    {
        public int Id;
        public string Name;
        public bool State;

        public Light(int idIn, bool stateIn, string nameIn)
        {
            Id = idIn;
            State = stateIn;
            Name = nameIn;
        }

        public static dynamic TurnOn(int idIn)
        {
            var turnOnUrl = Settings.BaseUrl + "/lights/"+ idIn + "/state";
            var http = new HttpClient();
            dynamic dataSend = new ExpandoObject();
            dataSend.on = true;
            var response = http.Put(uri:turnOnUrl,data:dataSend,contentType:HttpContentTypes.ApplicationJson);
            return response;
        }
        public dynamic TurnOn()
        {
            return TurnOn(Id);
        }        
        
        
        public static dynamic TurnOff(int idIn)
        {
            var turnOnUrl = Settings.BaseUrl + "/lights/"+ idIn + "/state";
            var http = new HttpClient();
            dynamic dataSend = new ExpandoObject();
            dataSend.on = false;
            var response = http.Put(uri:turnOnUrl,data:dataSend,contentType:HttpContentTypes.ApplicationJson);
            return response; 
        }
        public dynamic TurnOff()
        {
            return TurnOff(Id);
        }   
    }

    public static class Lights
    {
        public static List<Light> GetLightLight()
        {
            var lightList = new List<Light>();
            var lightListRaw = HttpHelper.GetSiteJson(Settings.BaseUrl).lights;

            foreach (var singleLight in lightListRaw)
            {
                var idParse = int.Parse(singleLight.Key);
                var nameParse = singleLight.Value.name;
                var stateParse = singleLight.Value.state.on;
                
                lightList.Add(new Light(idIn:idParse,nameIn:nameParse,stateIn:stateParse));
            }
            return lightList;
        }
    }
}