namespace VergeLibrary.Contracts.Response
{
    public class TransactionQueryResponse
    {
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public string TraceId { get; set; }
        public string TransactionId { get; set; }
        public string PaymentDate { get; set; }
        public string Channel { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string FeeBearer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PaymentInstrument { get; set; }
        public long TimeStamp { get; set; }
        public string Signature { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ChannelTransactionId { get; set; }
        public List<Refund> Refunds { get; set; }

    }

    public class Refund
    {
        public decimal Amount { get; set; }
        public string Channel { get; set; }
        public string RefundId { get; set; }
        public string TraceId { get; set; }
        public string TransactionId { get; set; }
        public string RefundDate { get; set; }
    }
}

