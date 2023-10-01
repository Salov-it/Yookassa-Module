using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text;
using Yookassa.Application.Interface;
using System;
using Yookassa.Domain.Refund;

namespace Yookassa.Application.CQRS.Command.PostRefundCommand
{
    public class Refund : IRefund
    {
        private readonly HttpClient? _httpClient;
        private readonly string _shopId;
        private readonly string _secretKey;
      
        public Refund(HttpClient? httpClient,IConfig config)
        {
            _httpClient = httpClient;
            _shopId = config.shopId();
            _secretKey = config.secretKey();    
        }
        public async Task<string> Return(RefundModel refundModel)
        {
            string url = "https://api.yookassa.ru/v3/refunds";
            // Устанавливаем заголовки запроса
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(_shopId + ":" + _secretKey)));

            _httpClient.DefaultRequestHeaders.Add("Idempotence-Key", refundModel.idempotenceKey);

           var content2 = new StringContent(JsonSerializer.Serialize(refundModel),
           Encoding.UTF8, "application/json");
           HttpResponseMessage response2 = await _httpClient.PostAsync(url,content2);
           string responseBody2 = await response2.Content.ReadAsStringAsync();
           return responseBody2;
        }
    }
}
