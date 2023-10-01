


namespace Yookassa.Domain.CancellationPayment
{
    public class CancellationPaymentModel
    {
        public string payment_id { get;set; }
        public string idempotenceKey { get; set; }
    }
}
