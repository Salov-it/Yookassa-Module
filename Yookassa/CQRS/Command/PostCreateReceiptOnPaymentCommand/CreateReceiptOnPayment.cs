using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Yookassa.Application.Interface;
using Yookassa.Domain.Check;

namespace Yookassa.Application.CQRS.Command.PostCreateCheckCommand
{
    public class CreateReceiptOnPayment : ICreateReceiptOnPayment
    {
        private readonly HttpClient? _httpClient;
        private readonly string _shopId;
        private readonly string _secretKey;

        public CreateReceiptOnPayment(HttpClient? httpClient, IConfig config)
        {
            _httpClient = httpClient;
            _shopId = config.shopId();
            _secretKey = config.secretKey();
        }

        public async Task<string> CreateReceiptOnPayments(CheckPayment.PaymentRequestModel checkPayment, string idempotenceKey)
        {
            string url = "https://api.yookassa.ru/v3/receipts";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
             Convert.ToBase64String(Encoding.UTF8.GetBytes(_shopId + ":" + _secretKey)));

            _httpClient.DefaultRequestHeaders.Add("Idempotence-Key", idempotenceKey);

            var jsonContent = JsonSerializer.Serialize(checkPayment);

            var jsonCheck = new StringContent(JsonSerializer.Serialize(checkPayment),
                Encoding.UTF8, "application/json");
            HttpResponseMessage response2 = await _httpClient.PostAsync(url,jsonCheck);
            string responseBody2 = await response2.Content.ReadAsStringAsync();
            return responseBody2;
        }
    }
}
