using static Yookassa.Domain.Check.CheckPayment;

namespace Yookassa.Domain.Refund
{
    public class RefundModel
    {
        public AmountModel amount { get; set; }
        public string payment_id { get; set; }
        public string idempotenceKey { get; set; }
    }
    public class AmountModel3
    {
        public decimal value { get; set; }
        public string currency { get; set; }
    }
}
