using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        public List<User> Get()
        {
            List<User> Users = null;
            using (var context = new InvoiceContext())
            {

                Users = context.Users.ToList();

            }
            return Users;
        }

        public User GetById(int ID)
        {
            User Users = null;

            using (var context = new InvoiceContext())
            {
                Users = context.Users.Find(ID);
            }

            return Users;
        }

        public void Insert(User User)
        {
            using (var context = new InvoiceContext())
            {
                context.Users.Add(User);
                context.SaveChanges();
            }
        }
    }
}
