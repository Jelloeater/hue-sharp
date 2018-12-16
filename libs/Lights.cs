using System.Collections.Generic;

namespace libs
{
    internal static class HttpHelper
    {
        public static dynamic GetSiteJson(string siteIn)
        {
            var http = new EasyHttp.Http.HttpClient();
            http.Request.Accept = EasyHttp.Http.HttpContentTypes.ApplicationJson;
            var response = http.Get(siteIn);
            return response.DynamicBody;
        }
    }

    public class Light
    {
        private string _name;
        private bool _state;

        public Light(bool state, string name)
        {
            _state = state;
            _name = name;
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
                var nameParse = singleLight.Value.name;
                var stateParse = singleLight.Value.state.on;
                lightList.Add(new Light(name:nameParse,state:stateParse));
            }
            return lightList;
        }
    }
}