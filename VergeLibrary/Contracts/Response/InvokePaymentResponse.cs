namespace VergeLibrary.Contracts.Response
{
    public class InvokePaymentResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public string TransactionId { get; set; }
        public string TraceId { get; set; }
        public string PayPageLink { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class ResponseHeader
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public long TimeStamp { get; set; }
        public string Signature { get; set; }
    }
}
