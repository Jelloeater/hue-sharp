using System.Collections.Generic;

namespace huesharp
{
    internal class HttpHelper
    {
        public dynamic GetSiteJson(string siteIn)
        {
            var http = new EasyHttp.Http.HttpClient();
            http.Request.Accept = EasyHttp.Http.HttpContentTypes.ApplicationJson;
            var response = http.Get(siteIn);
            return response.DynamicBody;
        }
    }

    public class Light
    {
        private string name;
        private bool state;

        public Light(bool state, string name)
        {
            this.state = state;
            this.name = name;
        }
    }

    public static class Lights
    {
        public static List<Light> GetLightLight()
        {
            var lightList = new List<Light>();
            var lightListRaw = new HttpHelper().GetSiteJson(Settings.BaseUrl).lights;

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