using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VergeLibrary.Contracts;

public class RequestHeader
{
    public string MerchantId { get; set; }
    public long TimeStamp { get; set; }
    public string Signature { get; set; }
    public string TerminalId { get; set; }
}
