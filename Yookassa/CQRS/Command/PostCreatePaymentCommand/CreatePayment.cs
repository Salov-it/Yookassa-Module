using System.Net.Http.Headers;
using System.Text;
using Yookassa.Application.Interface;
using System.Text.Json;
using Yookassa.Domain.CreatePayment;
using static Yookassa.Domain.CreatePayment.CreatePaymentCheckModel;

namespace Yookassa.Application.CQRS.Command.PostCreatePaymentCommand
{
    public class CreatePayment : ICreatePayment
    {
        private readonly HttpClient? _httpClient;
        private readonly string _shopId;
        private readonly string _secretKey;
        private readonly string _ApiUril;

        public CreatePayment(HttpClient httpClient, IConfig config)
        {
           _httpClient = httpClient;
           _secretKey = config.secretKey();
           _shopId = config.shopId();
           _ApiUril = config.ApiUril();
        }

        public async Task<string> CreatePaymentAsync(CreatePaymentModel.createPaymentModel createPaymentModel,
            string _Idempotence)
        {
            string url = _ApiUril;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes(_shopId + ":" + _secretKey)));

            _httpClient.DefaultRequestHeaders.Add("Idempotence-Key", _Idempotence);

            var content = new StringContent(JsonSerializer.Serialize(createPaymentModel), 
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url,content);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> CreatePaymentCheck(CreatePaymentCheckModel createPaymentCheckModel)
        {
            string url = _ApiUril;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes(_shopId + ":" + _secretKey)));

            _httpClient.DefaultRequestHeaders.Add("Idempotence-Key", createPaymentCheckModel.idempotence);

            var content = new StringContent(JsonSerializer.Serialize(createPaymentCheckModel),
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
