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
    public class DetailController : ApiController
    {
        private DetailService service = new DetailService();

        public List<Detail_Response_v1> Get()
        {
            //Mapper
            //Transforma un objeto de un tipo (Product) a otro tipo (ProductResponse)
            var response = (from c in service.Get()
                            select
                            new Detail_Response_v1
                            {
                                DetailID = c.DetailID,
                                InvoiceID = c.InvoiceID,
                                UserID = c.UserID,
                                ProductID = c.ProductID,
                                Quantity = c.Quantity,
                                Prize = c.Prize
                            }).ToList();

            return response;
        }

        public Detail Get(int id)
        {
            return service.GetById(id);
        }

        public void Post([FromBody] Detail_Request_v1 request)
        {
            Detail detail = new Detail();
            detail.InvoiceID = request.InvoiceID;
            detail.ProductID = request.ProductID;
            detail.Quantity = request.Quantity;
            detail.Prize = request.Prize;
            service.Insert(detail);
        }
        public void UpdateInvoice([FromBody] Detail_Request_V2 request)
        {

            Detail detail = new Detail();
            detail.DetailID = request.DetailID;
            detail.InvoiceID = request.InvoiceID;
            service.Update(detail, detail.DetailID);
        }

        public void UpdateProduct([FromBody] Detail_Request_V3 request)
        {

            Detail detail = new Detail();
            detail.DetailID = request.DetailID;
            detail.ProductID = request.ProductID;
            service.Update(detail, detail.DetailID);
        }

        public void UpdateQuantity([FromBody] Detail_Request_V4 request)
        {

            Detail detail = new Detail();
            detail.DetailID = request.DetailID;
            detail.Quantity = request.Quantity;
            service.Update(detail, detail.DetailID);
        }

        public void UpdatePrize([FromBody] Detail_Request_V5 request)
        {

            Detail detail = new Detail();
            detail.DetailID = request.DetailID;
            detail.Prize = request.Prize;
            service.Update(detail, detail.DetailID);
        }


        public void DeleteDetail([FromBody] Detail_Request_V6 request)
        {
            Detail detail = new Detail();
            detail.DetailID= request.DetailID;
            service.Delete(detail.DetailID);
        }
    }
}
