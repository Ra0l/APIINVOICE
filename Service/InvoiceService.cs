using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InvoiceService
    {
        public List<Invoice> Get()
        {
            List<Invoice> Invoices = null;
            using (var context = new InvoiceContext())
            {
                Invoices = context.Invoices.ToList();
            }
            return Invoices;
        }

        public void Insert(Invoice Invoice)
        {
            using (var context = new InvoiceContext())
            {
                Invoice.Date = DateTime.Today;
                context.Invoices.Add(Invoice);
                context.SaveChanges();
            }
        }

        public void Update(Invoice Invoice, int ID)
        {
            using (var context = new InvoiceContext())
            {
                var InvoiceNew = context.Invoices.Find(ID);
                InvoiceNew.InvoiceNumber = Invoice.InvoiceNumber == null ? InvoiceNew.InvoiceNumber : Invoice.InvoiceNumber;
                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new InvoiceContext())
            {
                var Invoice = context.Invoices.Find(ID);
                context.Invoices.Remove(Invoice);
                context.SaveChanges();
            }
        }
    }
}
