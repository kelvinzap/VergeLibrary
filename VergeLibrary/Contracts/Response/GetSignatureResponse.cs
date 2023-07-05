using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VergeLibrary.Contracts.Response
{
    public class GetSignatureResponse
    {
        public Contracts.Header Header { get; set; }
        public string Signature { get; set; }
    }
}
