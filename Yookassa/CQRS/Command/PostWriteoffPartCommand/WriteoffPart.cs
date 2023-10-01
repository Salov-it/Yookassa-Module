using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Yookassa.Application.Interface;
using Yookassa.Domain.WriteEverythingOff;
using Yookassa.Domain.WriteoffPart;

namespace Yookassa.Application.CQRS.Command.PostWriteoffPartCommand
{
    public class WriteoffPart : IWriteoffPart
    {
        private readonly HttpClient? _httpClient;
        private readonly string _shopId;
        private readonly string _secretKey;
        public WriteoffPart(HttpClient httpClient, IConfig config)
        {
            _httpClient = httpClient;
            _shopId = config.shopId();
            _secretKey = config.secretKey();    
        }
       async Task<string> IWriteoffPart.WriteoffPart(WriteoffPartModel writeoffPartModel)
       {
            string Uril = $"https://api.yookassa.ru/v3/payments/{writeoffPartModel.payment_id}/capture";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(_shopId + ":" + _secretKey)));

            _httpClient.DefaultRequestHeaders.Add("Idempotence-Key", writeoffPartModel.idempotenceKey);

            var content = new StringContent(JsonSerializer.Serialize(writeoffPartModel),
            Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(Uril, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
       }
    }
}
