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
    public class UserController : ApiController
    {
        private UserService service = new UserService();

        public List<User_Response_v1> Get()
        {
            //Mapper
            //Transforma un objeto de un tipo (Product) a otro tipo (ProductResponse)
            var response = (from c in service.Get()
                            select
                            new User_Response_v1
                            {
                                UserID = c.UserID,
                                Username = c.Username
                            }).ToList();

            return response;
        }

        public User Get(int id)
        {
            return service.GetById(id);
        }

        public void Post([FromBody] User_Request_v1 request)
        {
            User user = new User();
            user.Username = request.Username;
            user.Password = request.Password;
            user.UserTypeID = request.UserTypeID;
            service.Insert(user);
        }
    }
}
