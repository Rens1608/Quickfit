using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using Models;

namespace LogicLayer
{
    public class User
    {
        private string connectionstring;

        public User(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void UpdateUser(int id, string name, int age, int weight, int height, string gender)
        {
            UserFactory.CreateUserDAL().UpdateUser(id, name, age, weight, height, gender,connectionstring);
        }

        public UserModel Login(string name, string password)
        {
            return UserFactory.CreateUserDAL().LogIn(name, password, connectionstring);
        }
    }
}
