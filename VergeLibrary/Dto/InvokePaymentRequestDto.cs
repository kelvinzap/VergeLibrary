using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VergeLibrary.Contracts;


namespace VergeLibrary.Dto
{
    internal class InvokePaymentRequestDto
    {
        public RequestHeader RequestHeader { get; set; }
        public customer Customer { get; set; }
        public customization Customization { get; set; }
        public metaData MetaData { get; set; }
        public string ProductId { get; set; }
        public string TraceId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string FeeBearer { get; set; }
        public string ReturnUrl { get; set; }
    }
    internal class customer
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string TokenUserId { get; set; }
    }

    internal class customization
    {
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    internal class metaData
    {
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
    }


}
