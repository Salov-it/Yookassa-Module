using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Yookassa.Application.Interface;
using Yookassa.Domain.CancellationPayment;

namespace Yookassa.Application.CQRS.Command.PostCancellationPaymentCommand
{
    public class CancellationPayment : ICancellationPayment
    {
        private readonly HttpClient? _httpClient;
        private readonly string _shopId;
        private readonly string _secretKey;

        public CancellationPayment(HttpClient? httpClient, IConfig config)
        {
            _httpClient = httpClient;
            _shopId = config.shopId();
            _secretKey = config.secretKey();
        }

        public async Task<string> CancelAsync(CancellationPaymentModel cancellationPaymentModel)
        {
            string url = $"https://api.yookassa.ru/v3/payments/{cancellationPaymentModel.payment_id}/cancel";
            // Устанавливаем заголовки запроса
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(_shopId + ":" + _secretKey)));

            _httpClient.DefaultRequestHeaders.Add("Idempotence-Key", cancellationPaymentModel.idempotenceKey);

            // Создаем тело запроса
            var requestBody = new
            {
               
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody),
                Encoding.UTF8, "application/json");

            // Отправляем запрос и получаем ответ
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}

