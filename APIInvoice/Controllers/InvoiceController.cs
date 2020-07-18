using APIInvoice.Models.Request;
using APIInvoice.Models.Response;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIInvoice.Controllers
{
    public class InvoiceController : ApiController
    {
        private InvoiceService service = new InvoiceService();

        public List<Invoice_Response_v1> Get()
        {
            var response = (from c in service.Get()
                            select
                            new Invoice_Response_v1
                            {
                                InvoiceID = c.InvoiceID,
                                InvoiceNumber = c.InvoiceNumber
                            }).ToList();
            return response;
        }

        public void Post([FromBody] Invoice_Request_v1 request)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceNumber = request.InvoiceNumber;
            service.Insert(invoice);
        }

        public void UpdateNumber([FromBody] Invoice_Request_v2 request)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceID = request.InvoiceID;
            invoice.InvoiceNumber = request.InvoiceNumber;
            service.Update(invoice, invoice.InvoiceID);
        }

        public void DeleteInvoice([FromBody] Invoice_Request_v3 request)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceID = request.InvoiceID;
            service.Delete(invoice.InvoiceID);
        }
    }
}
