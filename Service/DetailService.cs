using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DetailService
    {
        public List<Detail> Get()
        {
            List<Detail> Details = null;
            using (var context = new InvoiceContext())
            {

                Details = context.Details.ToList();

            }
            return Details;
        }

        public Detail GetById(int ID)
        {
            Detail Detail = null;

            using (var context = new InvoiceContext())
            {
                Detail = context.Details.Find(ID);
            }

            return Detail;
        }

        public void Insert(Detail Detail)
        {
            using (var context = new InvoiceContext())
            {
                Detail.UserID = 1;
                context.Details.Add(Detail);
                context.SaveChanges();
            }
        }

        public void Update(Detail Detail, int ID)
        {
            using (var context = new InvoiceContext())
            {
                var DetailNew = context.Details.Find(ID);
                DetailNew.Quantity = Detail.Quantity == 0 ? DetailNew.Quantity : Detail.Quantity;
                DetailNew.Prize = Detail.Prize == 0 ? DetailNew.Prize : Detail.Prize;
                DetailNew.UserID = Detail.UserID == 0? DetailNew.UserID : Detail.UserID;
                DetailNew.ProductID = Detail.ProductID == 0 ? DetailNew.ProductID : Detail.ProductID;
                DetailNew.ProductID = Detail.InvoiceID == 0 ? DetailNew.InvoiceID : Detail.InvoiceID;
                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new InvoiceContext())
            {
                var Detail = context.Details.Find(ID);
                context.Details.Remove(Detail);
                context.SaveChanges();
            }
        }
    }
}
