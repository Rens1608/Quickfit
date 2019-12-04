using System;
using System.Collections.Generic;
using System.Text;
using ILayer;
using Models;
using Factory;

namespace LogicLayer
{
    public class UserContainer
    {
        public void Add(UserModel userModel)
        {
            UserFactory.CreateUserContainerDAL().Add(userModel);
        }

        public void Delete(int id)
        {
            UserFactory.CreateUserContainerDAL().Delete(id);
        }

        public UserModel FindById(int id)
        {
            return UserFactory.CreateUserContainerDAL().FindById(id);
        }
    }
}
