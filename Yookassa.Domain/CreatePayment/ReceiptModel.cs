

namespace Yookassa.Domain.CreatePayment
{
    public class ReceiptModel
    {
        public Customer customer { get; set; }
        public string type { get; set; }
        public string payment_id { get; set; }
        public string on_behalf_of { get; set; }
        public bool send { get; set; }
        public List<Item> items { get; set; }
        public int tax_system_code { get; set; }
        public List<Settlement> settlements { get; set; }

        public class Customer
        {
            public string email { get; set; }
            public string phone { get; set; }
        }

        public class Amount
        {
            public string value { get; set; }
            public string currency { get; set; }
        }

        public class Item
        {
            public string description { get; set; }
            public string quantity { get; set; }
            public Amount amount { get; set; }
            public int vat_code { get; set; }
            public string payment_mode { get; set; }
            public string payment_subject { get; set; }
        }

        public class Settlement
        {
            public string type { get; set; }
            public Amount amount { get; set; }
        }

    }
}
