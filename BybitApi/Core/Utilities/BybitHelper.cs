using Bybit.Entity.Models.Public;
using System.Globalization;
using System.Net.Http.Json;
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
        const string BASE_URL_2 = "https://api.bytick.com/";

        private static readonly HttpClient _httpClient = new();

        internal static string GetRequestUrl(string url, string version = "")
        {
            version = string.IsNullOrEmpty(version) ? VERSION : version;
            return $"{BASE_URL}{version}{url}";
        }

        internal static string CreateQueryString(Dictionary<string, string>? parameters)
        {
            parameters ??= new Dictionary<string, string>();
            return $"?{string.Join("&", parameters.Where(p => !string.IsNullOrEmpty(p.Value))
                .Select(p => $"{p.Key}={HttpUtility.UrlEncode(p.Value)}"))}";
        }

        public static string CreateHmac(string data, string secretKey)
        {
            using var sha256_HMAC = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            return BitConverter.ToString(sha256_HMAC.ComputeHash(Encoding.UTF8.GetBytes(data))).Replace("-", string.Empty).ToLower();
        }

        public static long GetTimestamp(DateTime? dateTime = null)
        {
            //return new DateTimeOffset(dateTime ?? DateTime.UtcNow).ToUnixTimeMilliseconds();
            var offset = new TimeSpan().TotalMilliseconds;
            var targetDateTime = dateTime ?? DateTime.UtcNow;
            return (long)(targetDateTime.AddMilliseconds(offset) - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static async Task<string> GetTimestampFromServer(CancellationToken ct = default)
        {
            var serverTime = await GetServerTimeAsync(ct);
            var serverDate = DateTimeOffset.FromUnixTimeSeconds(serverTime);

            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (long)Math.Round((serverDate.AddMilliseconds(-1) - epoch).TotalMilliseconds);
            return timestamp.ToString(CultureInfo.InvariantCulture);
        }

        public static async Task<long> GetServerTimeAsync(CancellationToken ct = default)
        {
            try
            {
                var response = await _httpClient.GetAsync("https://api.bybit.com//v3/public/time", ct);
                response.EnsureSuccessStatusCode();
                var serverTimeResponse = await response.Content.ReadFromJsonAsync<ServerTimeModel>(cancellationToken: ct);
                return serverTimeResponse?.Result?.TimeSecond ?? 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
