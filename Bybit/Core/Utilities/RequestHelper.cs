using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Entity;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Bybit.Core.Utilities
{
    public static class RequestHelper
    {
        private static readonly Encoding _encoding = Encoding.UTF8;
        const string _recvWindow = "5000";

        public static async Task<IDataResult<T?>> SendRequestAsync<T>(string url, Dictionary<string, string>? parameters = null, string version = "", CancellationToken ct = default)
        {
            try
            {
                using var httpClient = new HttpClient();
                var requestUri = BybitHelper.GetRequestUrl(url, version);

                //var queryString = BybitHelper.CreateQueryString(BybitHelper.BuildRequest(null, parameters));
                var queryString = BybitHelper.CreateQueryString(parameters);
                var fullRequestUri = new UriBuilder(requestUri) { Query = queryString }.Uri;

                var response = await httpClient.GetAsync(fullRequestUri, ct);
                var data = await response.Content.ReadFromJsonAsync<T?>(cancellationToken: ct);
                return new SuccessDataResult<T?>(data);
            }
            catch (HttpRequestException ex)
            {
                // İsteği gönderirken bir hata oluştu
                return new ErrorDataResult<T?>(ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // İşlem iptal edildi
                return new ErrorDataResult<T?>(ex.Message);
            }
            catch (Exception ex)
            {
                // Diğer hatalar
                return new ErrorDataResult<T?>(ex.Message);
            }
        }

        public static async Task<IDataResult<T?>> SendRequestWithAuthAsync<T>(HttpMethod method, string url, BybitOptions options, Dictionary<string, string> parameters = null, CancellationToken ct = default)
        {
            try
            {
                var paramStr = method == HttpMethod.Post
                    ? JsonSerializer.Serialize(parameters)
                    : BybitHelper.CreateQueryString(parameters)?.Replace("?", "");

                var requestUrl = BybitHelper.GetRequestUrl(url);

                if (method == HttpMethod.Get)
                    requestUrl += $"?{paramStr}";

                var requestMessage = new HttpRequestMessage(method, requestUrl);

                if (method == HttpMethod.Post)
                    requestMessage.Content = new StringContent(paramStr ?? "", _encoding, "application/json");

                //var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(CultureInfo.InvariantCulture);
                var timestamp = await BybitHelper.GetTimestampFromServer(ct);
                var signature = BybitHelper.CreateHmac($"{timestamp}{options.ApiKey}{_recvWindow}{paramStr}", options.SecretKey);

                requestMessage.Headers.Add("X-BAPI-API-KEY", options.ApiKey);
                requestMessage.Headers.Add("X-BAPI-SIGN", signature);
                requestMessage.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
                requestMessage.Headers.Add("X-BAPI-RECV-WINDOW", _recvWindow);

                using var httpClient = new HttpClient();
                var response = await httpClient.SendAsync(requestMessage, ct);

                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<T?>(cancellationToken: ct);
                return new SuccessDataResult<T?>(data);
            }
            catch (HttpRequestException ex)
            {
                // İsteği gönderirken bir hata oluştu
                return new ErrorDataResult<T?>(ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // İşlem iptal edildi
                return new ErrorDataResult<T?>(ex.Message);
            }
            catch (Exception ex)
            {
                // Diğer hatalar
                return new ErrorDataResult<T?>(ex.Message);
            }
        }

        public static async Task<string> SendRequestAsync(string url, Dictionary<string, string>? parameters = null, string version = "", CancellationToken ct = default)
        {
            try
            {
                using var httpClient = new HttpClient();
                var requestUri = BybitHelper.GetRequestUrl(url, version);

                //var queryString = BybitHelper.CreateQueryString(BybitHelper.BuildRequest(null, parameters));
                var queryString = BybitHelper.CreateQueryString(parameters);
                var fullRequestUri = new UriBuilder(requestUri) { Query = queryString }.Uri;

                var response = await httpClient.GetAsync(fullRequestUri, ct);
                return await response.Content.ReadAsStringAsync(ct);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static async Task<string> SendRequestWithAuthAsync(HttpMethod method, string url, BybitOptions options, Dictionary<string, string> parameters = null, CancellationToken ct = default)
        {
            try
            {
                var paramStr = method == HttpMethod.Post
                    ? JsonSerializer.Serialize(parameters)
                    : BybitHelper.CreateQueryString(parameters)?.Replace("?", "");

                var requestUrl = BybitHelper.GetRequestUrl(url);

                if (method == HttpMethod.Get)
                    requestUrl += $"?{paramStr}";

                var requestMessage = new HttpRequestMessage(method, requestUrl);

                if (method == HttpMethod.Post)
                    requestMessage.Content = new StringContent(paramStr ?? "", _encoding, "application/json");

                //var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(CultureInfo.InvariantCulture);
                var timestamp = await BybitHelper.GetTimestampFromServer(ct);
                var signature = BybitHelper.CreateHmac($"{timestamp}{options.ApiKey}{_recvWindow}{paramStr}", options.SecretKey);

                requestMessage.Headers.Add("X-BAPI-API-KEY", options.ApiKey);
                requestMessage.Headers.Add("X-BAPI-SIGN", signature);
                requestMessage.Headers.Add("X-BAPI-TIMESTAMP", timestamp);
                requestMessage.Headers.Add("X-BAPI-RECV-WINDOW", _recvWindow);

                using var httpClient = new HttpClient();
                var response = await httpClient.SendAsync(requestMessage, ct);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync(ct);
            }
            catch (HttpRequestException ex)
            {
                // İsteği gönderirken bir hata oluştu
                return ex.Message;
            }
            catch (TaskCanceledException ex)
            {
                // İşlem iptal edildi
                return ex.Message;
            }
            catch (Exception ex)
            {
                // Diğer hatalar
                return ex.Message;
            }
        }
    }
}
