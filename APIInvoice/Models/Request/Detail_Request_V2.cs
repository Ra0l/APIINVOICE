using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIInvoice.Models.Request
{
    public class Detail_Request_V2
    {
        public int DetailID { get; set; }
        public int InvoiceID { get; set; }
    }

    public class Detail_Request_V3
    {
        public int DetailID { get; set; }
        public int ProductID { get; set; }
    }

    public class Detail_Request_V4
    {
        public int DetailID { get; set; }
        public int Quantity { get; set; }
    }

    public class Detail_Request_V5
    {
        public int DetailID { get; set; }
        public int Prize { get; set; }
    }

    public class Detail_Request_V6
    {
        public int DetailID { get; set; }
    }
}