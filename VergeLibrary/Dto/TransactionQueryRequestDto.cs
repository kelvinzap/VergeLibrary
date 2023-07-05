using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VergeLibrary.Contracts;


namespace VergeLibrary.Dto
{
    internal class TransactionQueryRequestDto
    {
        public RequestHeader RequestHeader { get; set; }
        public string TraceId { get; set; }
    }

   

}
