
namespace Yookassa.Domain.CreatePayment
{
    public class CreatePaymentModel
    {
        public class createPaymentModel
        {
            public AmountModel2 amount { get; set; }
            public bool capture { get; set; }
            public ConfirmationModel confirmation { get; set; }
            public string description { get; set; }
            public string idempotence { get; set; }
        }

        public class AmountModel2
        {
            public decimal value { get; set; }
            public string currency { get; set; }
        }

        public class ConfirmationModel
        {
            public string type { get; set; }
            public string return_url { get; set; }
        }
    }
}
