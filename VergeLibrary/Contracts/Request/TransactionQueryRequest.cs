using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VergeLibrary.Contracts.Request;

public class TransactionQueryRequest
{
    public RequestHeader RequestHeader { get; set; }
    public string Url  { get; set; }
    public string Token { get; set; }
    public string TraceId { get; set; }
}

