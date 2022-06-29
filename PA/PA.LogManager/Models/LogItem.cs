namespace PA.Log.Manager.Models
{
    public class LogItem
    {
        public string INFORMATION_TYPE { get; set; }
        public string ID { get; set; }
        public string ApiId { get; set; }
        public string UserId { get; set; }
        public int ApiType { get; set; }
        public Rawrequest RawRequest { get; set; }
        public string Message { get; set; }
        public string Host { get; set; }
        public string Duration { get; set; }
        public string Response { get; set; }
        public DateTime Time { get; set; }
    }
    

    public enum ApiType
    {
        Get = 1,
        Post = 2,
        Put = 4,
        Delete = 8,
        Head = 16,
        Patch = 32,
        Options = 64,
    }

    public class Rawrequest
    {
        public string ApiId { get; set; }
        public Apiconnectioninformation ApiConnectionInformation { get; set; }
        public Infodictionary[] InfoDictionary { get; set; }
        public ApiType ApiType { get; set; }
    }

    public class Apiconnectioninformation
    {
        public string ApiUrl { get; set; }
        public object BillingUrl { get; set; }
        public string ApiUserName { get; set; }
        public string SoapApiUrl { get; set; }
        public string SoapApiUserName { get; set; }
    }

    public class Infodictionary
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public int Type { get; set; }
        public bool IsGlobal { get; set; }
    }

}