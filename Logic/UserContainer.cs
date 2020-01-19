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
        private string connectionstring;

        public UserContainer(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void Add(UserModel userModel)
        {
            UserFactory.CreateUserContainerDAL().Add(userModel, connectionstring);
        }

        public void Delete(int id)
        {
            UserFactory.CreateUserContainerDAL().Delete(id, connectionstring);
        }

        public UserModel FindById(int id)
        {
            return UserFactory.CreateUserContainerDAL().FindById(id, connectionstring);
        }

        public List<UserModel> GetAll()
        {
            return UserFactory.CreateUserContainerDAL().GetAll(connectionstring);
        }
    }
}
