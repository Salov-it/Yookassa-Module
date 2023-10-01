

namespace Yookassa.Domain.WriteoffPart
{
    public class WriteoffPartModel
    {
        public Guid payment_id { get; set; }
        public string idempotenceKey { get; set; }
        public Amount4 amount { get; set; }
        
    }
    public class Amount4
    {
        public string value { get; set; }
        public string currency { get; set; }
    }
}
