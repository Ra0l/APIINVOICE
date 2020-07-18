using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Invoice_Request_v2
    {

        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
    }

    public class Invoice_Request_v3
    {

        public int InvoiceID { get; set; }
    }
}