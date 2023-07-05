using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using VergeLibrary.Contracts;
using VergeLibrary.Contracts.Request;
using VergeLibrary.Contracts.Response;
using VergeLibrary.Dto;
using Customer = VergeLibrary.Contracts.Request.Customer;
using Customization = VergeLibrary.Contracts.Request.Customization;
using MetaData = VergeLibrary.Contracts.MetaData;
using RequestHeader = VergeLibrary.Contracts.RequestHeader;

namespace VergeLibrary.Actions
{
    public static class Utilities
    {
        public static GetSignatureResponse GetSignature(string merchantId, string traceId, string unixTimeStamp, string key)
        {
            try
            {
                var values = merchantId + traceId + unixTimeStamp + key;
                var signature = new StringBuilder();
                using (var hash = SHA256.Create())
                {
                    var encoding = Encoding.UTF8;
                    var result = hash.ComputeHash(encoding.GetBytes(values));

                    foreach (var b in result)
                    {
                        signature.Append(b.ToString("x2"));
                    }
                }

                return new GetSignatureResponse
                {
                    Header = new Header
                    {
                        ResponseCode = "00",
                        ResponseMessage = "Successful"
                    },
                    Signature = signature.ToString()
                };

            }
            catch (Exception ex)
            {

                return new GetSignatureResponse
                {
                    Header = new Header
                    {
                        ResponseCode = "00",
                        ResponseMessage = ex.Message
                    },
                };
            }
            
        }

        //or long?
        public static long GetTimeStamp()
        {
            var now = DateTime.UtcNow;
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var unixTimeStamp = (long)(now - unixEpoch).TotalSeconds;
            return unixTimeStamp;
        }

        public static async Task<InvokePaymentResponse> InvokePayment(InvokePaymentRequest invokePaymentRequest)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", invokePaymentRequest.Token);
                
                var request = new InvokePaymentRequestDto()
                {
                    RequestHeader = new RequestHeader
                    {
                        MerchantId = invokePaymentRequest.RequestHeader.MerchantId,
                        TimeStamp = invokePaymentRequest.RequestHeader.TimeStamp,
                        Signature = invokePaymentRequest.RequestHeader.Signature,
                        TerminalId = invokePaymentRequest.RequestHeader.TerminalId
                    },
                    Customer = new customer
                    {
                        Email = invokePaymentRequest.Customer.Email,
                        Name = invokePaymentRequest.Customer.Name,
                        Phone = invokePaymentRequest.Customer.Phone,
                        TokenUserId = invokePaymentRequest.Customer.TokenUserId
                    },
                    Customization = new customization
                    {
                        Description = invokePaymentRequest.Customization.Description,
                        Title = invokePaymentRequest.Customization.Title,
                        LogoUrl = invokePaymentRequest.Customization.LogoUrl
                    },
                    MetaData = new metaData
                    {
                        Data1 = invokePaymentRequest.MetaData.Data1,
                        Data2 = invokePaymentRequest.MetaData.Data2,
                        Data3 = invokePaymentRequest.MetaData.Data3
                    },
                    TraceId = invokePaymentRequest.TraceId,
                    ProductId = invokePaymentRequest.ProductId,
                    Amount = invokePaymentRequest.Amount,
                    Currency = invokePaymentRequest.Currency,
                    FeeBearer = invokePaymentRequest.FeeBearer,
                    ReturnUrl = invokePaymentRequest.ReturnUrl

                };

                var response = await client
                    .PostAsJsonAsync(invokePaymentRequest.Url, request);

                var responseContent = await response.Content.ReadAsStringAsync();
                //what data type for meta data
                var result = JsonConvert.DeserializeObject<InvokePaymentResponse>(responseContent);
                return result;
            }
            catch (Exception ex)
            {
                return new InvokePaymentResponse
                {
                    ResponseHeader = new ResponseHeader()
                    {
                        ResponseCode = "01",
                        ResponseMessage = ex.Message
                    }
                };
            }
           
        }

        public static async Task<TransactionQueryResponse> TransactionQuery(TransactionQueryRequest transactionQueryRequest)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", transactionQueryRequest.Token);

            
                var request = new TransactionQueryRequestDto
                {
                    RequestHeader = new RequestHeader()
                    {
                        MerchantId = transactionQueryRequest.RequestHeader.MerchantId,
                        TimeStamp = transactionQueryRequest.RequestHeader.TimeStamp,
                        Signature = transactionQueryRequest.RequestHeader.Signature,
                        TerminalId = transactionQueryRequest.RequestHeader.TerminalId
                    },
                    TraceId = transactionQueryRequest.TraceId
                };

               
                var response = await client
                    .PostAsJsonAsync(transactionQueryRequest.Url, request);
                
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TransactionQueryResponse>(responseContent);
                return result;
            }
            catch (Exception ex)
            {
                return new TransactionQueryResponse()
                {
                    ResponseCode = "01",
                    ResponseMessage = ex.Message
                };
            }
          
        }
    }
}
