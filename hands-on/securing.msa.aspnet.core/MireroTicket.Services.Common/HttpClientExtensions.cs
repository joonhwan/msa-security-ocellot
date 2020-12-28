using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MireroTicket.Services.Common
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"API Service Error : {response.ReasonPhrase}");
            }

            // https://devblogs.microsoft.com/dotnet/configureawait-faq/
            // --> `ConfigureAwait(false)` 를 제거하면, await 에서 return 되어 이어서 실행되는 쓰레드가
            //     호출시의 쓰레드와 정확히 일치하도록 스케쥴링된단다. WinForm등 GUI 프로그램에서는 이런 동작이 유용하
            //     지만, 여기 Web Api Service 에서는 꼭 그래야 할 필요가 없고, 다른 쓰레드에서 이어 실행하도록 하는 
            //     것이 더 성능상 이득이 된단다.
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}