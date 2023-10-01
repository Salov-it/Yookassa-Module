
namespace Yookassa.Domain.CreatePayment
{
    public class CreatePaymentCheckModel
    {

       public AmountModel3 amount { get; set; }
       public bool capture { get; set; }
       public ConfirmationModel3 confirmation { get; set; }
       public string description { get; set; }
       public string idempotence { get; set; }
       public ReceiptModel receipt { get; set; }
        
        public class AmountModel3
        {
            public decimal value { get; set; }
            public string currency { get; set; }
        }

        public class ConfirmationModel3
        {
            public string type { get; set; }
            public string return_url { get; set; }
        }
    }
}
