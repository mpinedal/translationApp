using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public class UserManagement
    {

        public static User login;

        private UserCrudFactory crudUser;

        public UserManagement()
        {
            crudUser = new UserCrudFactory();
        }

        public string LogIn(User user)
        {

            var u = crudUser.Retrieve<User>(user);
            if (u != null)
            {

                if (u.Password == user.Password)
                {
                    //Grant access
                    login = u;
                    return "loggedIn";
                }

            }

            return "fail";


        }

        public string Create(User user)
        {
          
                var u = crudUser.Retrieve<User>(user);
                if (u != null)
                {
                    //User exists already
                    string answer = "Fail";
                    return answer;
                }
                else
                {
                    crudUser.Create(user);
                    string answer = "Success";
                    return answer;
                }
            

         

        }
    }
}
