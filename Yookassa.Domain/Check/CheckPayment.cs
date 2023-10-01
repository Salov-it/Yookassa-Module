

namespace Yookassa.Domain.Check
{
    public class CheckPayment
    {
        public class PaymentRequestModel
        {
            public CustomerModel customer { get; set; }
            public string type { get; set; }
            public string payment_id { get; set; }
            public string on_behalf_of { get; set; }
            public bool send { get; set; }
            public List<ItemModel> items { get; set; }
            public int tax_system_code { get; set; }
            public List<SettlementModel> settlements { get; set; }
        }

        public class CustomerModel
        {
            public string email { get; set; }
            public string phone { get; set; }
        }

        public class ItemModel
        {
            public string description { get; set; }
            public string quantity { get; set; }
            public AmountModel amount { get; set; }
            public int vat_code { get; set; }
            public string payment_mode { get; set; }
            public string payment_subject { get; set; }
        }

        public class AmountModel
        {
            public string value { get; set; }
            public string currency { get; set; }
        }

        public class SettlementModel
        {
            public string type { get; set; }
            public AmountModel amount { get; set; }
        }
    }
}
