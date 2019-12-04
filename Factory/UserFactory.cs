using System;
using System.Collections.Generic;
using System.Text;
using ILayer;
using Data;

namespace Factory
{
    public static class UserFactory
    {
        public static IUserContainerDAL CreateUserContainerDAL()
        {
            IUserContainerDAL userContainerDAL = new UserDAL();
            return userContainerDAL;
        }

        public static IUserDAL CreateUserDAL()
        {
            IUserDAL userDAL = new UserDAL();
            return userDAL;
        }
    }
}
