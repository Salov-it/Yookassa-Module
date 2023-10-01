using Yookassa.Application.Interface;

namespace Yookassa.Application.Configs
{
    public class Config : IConfig
    {
        public string ApiUril = "https://api.yookassa.ru/v3/payments";

        //Идентификатор магазина
        public string shopId = "250380";

        public string secretKey = "test_HpMySmDaaDXzVV-qL8bfembTy5SJlGJsb1NFtAIVAPo";

        string IConfig.ApiUril()
        {
            return ApiUril;
        }

        string IConfig.secretKey()
        {
            return secretKey;
        }

        string IConfig.shopId()
        {
            return shopId;
        }
    }
}
