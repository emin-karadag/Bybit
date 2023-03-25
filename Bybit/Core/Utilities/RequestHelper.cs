namespace Bybit.Core.Utilities
{
    public static class RequestHelper
    {
        public static async Task<string> SendRequestAsync(string url, Dictionary<string, string>? parameters = null, CancellationToken ct = default)
        {
            try
            {
                using var httpClient = new HttpClient();
                var requestUri = BybitHelper.GetRequestUrl(url);

                var queryString = BybitHelper.CreateQueryString(BybitHelper.BuildRequest(null, parameters));
                var fullRequestUri = new UriBuilder(requestUri) { Query = queryString }.Uri;

                var response = await httpClient.GetAsync(fullRequestUri, ct);
                return await response.Content.ReadAsStringAsync(ct);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
