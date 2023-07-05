using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VergeLibrary.Contracts.Request;

public class InvokePaymentRequest
{
    public RequestHeader RequestHeader { get; set; }
    public Customer Customer { get; set; }
    public Customization Customization { get; set; }
    public MetaData MetaData { get; set; }
    public string Url { get; set; }
    public string Token { get; set; }
    public string ProductId { get; set; }
    public string TraceId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string FeeBearer { get; set; }
    public string ReturnUrl { get; set; }
}
public class Customer
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string TokenUserId { get; set; }
}

public class Customization
{
    public string LogoUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}







