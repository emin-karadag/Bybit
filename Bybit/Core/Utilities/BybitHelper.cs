using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Bybit.Core.Utilities
{
    public static class BybitHelper
    {
        const string VERSION = "v5";
        const string TESTNET_URL = "https://api-testnet.bybit.com";
        const string BASE_URL = "https://api.bybit.com/";
        const string BASE_URL_2 = "https://api.bytick.com";

        internal static string GetRequestUrl(string url)
        {
            return $"{BASE_URL}{VERSION}{url}";
        }

        internal static string CreateQueryString(Dictionary<string, string> parameters)
        {

            return $"?{string.Join("&", parameters.Where(p => !string.IsNullOrEmpty(p.Value))
                .Select(p => $"{p.Key}={HttpUtility.UrlEncode(p.Value)}"))}";


            //var properties = from p in parameters
            //                 where !string.IsNullOrEmpty(p.Value)
            //                 select $"{p.Key}={HttpUtility.UrlEncode(p.Value)}";

            //return "?" + string.Join("&", properties.ToArray());
        }


        public static Dictionary<string, string> BuildRequest(string? apiSecret = null, Dictionary<string, string>? parameters = null)
        {
            parameters ??= new Dictionary<string, string>();

            //if (baseUrl)
            //    parameters.Add("timestamp", GetTimestamp().ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(apiSecret))
                parameters.Add("signature", CreateHmac(apiSecret, new FormUrlEncodedContent(parameters)));

            return parameters;
        }


        public static string CreateHmac(string secretKey, FormUrlEncodedContent args)
        {
            using HMACSHA256 hash = new(Encoding.ASCII.GetBytes(secretKey));
            byte[] bytes = hash.ComputeHash(args.ReadAsByteArrayAsync().Result);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public static long GetTimestamp(DateTime? dateTime = null)
        {
            var targetDateTime = dateTime ?? DateTime.UtcNow;
            var offset = new TimeSpan().TotalMilliseconds;
            return (long)(targetDateTime.AddMilliseconds(offset) - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}
