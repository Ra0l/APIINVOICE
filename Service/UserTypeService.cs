using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserTypeService
    {
        public List<UserType> Get()
        {
            List<UserType> Users = null;
            using (var context = new InvoiceContext())
            {

                Users = context.UserTypes.ToList();

            }
            return Users;
        }

        public UserType GetById(int ID)
        {
            UserType Users = null;

            using (var context = new InvoiceContext())
            {
                Users = context.UserTypes.Find(ID);
            }

            return Users;
        }

        public void Insert(UserType User)
        {
            using (var context = new InvoiceContext())
            {
                context.UserTypes.Add(User);
                context.SaveChanges();
            }
        }
    }
}
