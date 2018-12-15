namespace huesharp
{
    public class SettingsExample
//    Rename me for your own usage to "Settings"
    {
        private const string Ip = "127.0.0.1";
        private const string ApiUser = "API_KEY_GOES_HERE";
        public static string BaseUrl = "http://" + Ip + "/api/" + ApiUser;
    }
}