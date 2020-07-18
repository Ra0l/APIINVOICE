using APIInvoice.Models.Request;
using APIInvoice.Models.Response;
using Datos;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIInvoice.Controllers
{
    public class ProductController : ApiController
    {
        private InvoiceDBEntities dbContext = new InvoiceDBEntities();
        private ProductService service = new ProductService();

        public List<Product_Response_v1> GetAll()
        {
            //Mapper
            //Transforma un objeto de un tipo (Product) a otro tipo (ProductResponse)
            var response = (from c in service.Get()
                           select
                           new Product_Response_v1
                           {
                               ProductID = c.ProductID,
                               ProductName = c.ProductName,
                               Prize = c.Prize,
                               Stock = c.Stock
                           }).ToList();

            return response;
        }

        public Product Get(int id)
        {
            return service.GetById(id);
        }


        public void PutAllProduct([FromBody] Product_Request_v0 request)
        {
            Product product = new Product();
            product.ProductID = request.ProductID;
            product.Prize = request.Prize;
            product.Stock = request.Stock;
            service.Update(product, product.ProductID);
        }

        public void Post([FromBody] Product_Request_v1 request)
        {
            //Ingreso un objeto de tipo Product_Request_v1
            //TRANSFORMAR
            //Necesito un objeto de tipo Product
            Product product = new Product();            
            product.ProductName = request.ProductName;
            product.Prize = request.Prize;
            product.Stock = request.Stock;            
            service.Insert(product); 
        }
        public void UpdatePrize([FromBody] Product_Request_v2 request)
        {
            
            Product product = new Product();
            product.ProductID = request.ProductID;
            product.Prize = request.Prize;                        
            service.Update(product,product.ProductID);
        }
        public void UpdateName([FromBody] Product_Request_v3 request)
        {

            Product product = new Product();
            product.ProductID = request.ProductID;
            product.ProductName = request.ProductName;
            service.Update(product, product.ProductID);
        }

        public void DeleteProduct([FromBody] Product_Request_v4 request)
        {
            Product product = new Product();
            product.ProductID = request.ProductID;
            service.Delete(product.ProductID);
        }

        
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, [FromBody]Product prod)
        {
            if (ModelState.IsValid)
            {
                var ProductoExiste = dbContext.Products.Count(c => c.ProductID == id) > 0;
                if (ProductoExiste)
                {
                    dbContext.Entry(prod).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id)
        {
            var pro = dbContext.Products.Find(id);

            if(pro != null)
            {
                dbContext.Products.Remove(pro);
                dbContext.SaveChanges();

                return Ok(pro);
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}
