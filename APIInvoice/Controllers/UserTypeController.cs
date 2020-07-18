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
    public class UserTypeController : ApiController
    {
        private UserTypeService service = new UserTypeService();

        public List<UserType_Response_v1> Get()
        {
            //Mapper
            //Transforma un objeto de un tipo (Product) a otro tipo (ProductResponse)
            var response = (from c in service.Get()
                            select
                            new UserType_Response_v1
                            {
                                UserTypeID = c.UserTypeID,
                                UserTypeName = c.UserTypeName
                            }).ToList();

            return response;
        }

        public UserType Get(int id)
        {
            return service.GetById(id);
        }

        public void Post([FromBody] UserType_Request_v1 request)
        {
            UserType userType = new UserType();
            userType.UserTypeName = request.UserTypeName;
            service.Insert(userType);
        }
    }
}
