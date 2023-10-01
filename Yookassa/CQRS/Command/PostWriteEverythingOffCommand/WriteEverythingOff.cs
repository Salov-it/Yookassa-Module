using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Yookassa.Application.Interface;
using Yookassa.Domain.WriteEverythingOff;

namespace Yookassa.Application.CQRS.Command.PostWriteEverythingOffCommand
{
    public class WriteEverythingOff : IWriteEverythingOff
    {
        private readonly HttpClient? _httpClient;
        private readonly string _shopId;
        private readonly string _secretKey;
        public string Resuilt { get; set; }
        public WriteEverythingOff(HttpClient httpClient, IConfig config)
        {
            _httpClient = httpClient;
            _shopId = config.shopId();
            _secretKey = config.secretKey();    
        }

        public async Task<string> WriteOffAll(WriteEverythingOffModel1 writeEverythingOffModel1)
        {
            string Uril = $"https://api.yookassa.ru/v3/payments/{writeEverythingOffModel1.payment_id}/capture";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(_shopId + ":" + _secretKey)));

            _httpClient.DefaultRequestHeaders.Add("Idempotence-Key", writeEverythingOffModel1.idempotenceKey);

            var Content = new
            {

            };

            var content = new StringContent(JsonSerializer.Serialize(Content),
            Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(Uril,content);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
  
}
