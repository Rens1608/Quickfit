using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using Models;

namespace LogicLayer
{
    public class User
    {
        public void UpdateUser(int id, string name, int age, int weight, int height, string gender)
        {
            UserFactory.CreateUserDAL().UpdateUser(id, name, age, weight, height, gender);
        }

        public UserModel Login(string name, string password)
        {
            return UserFactory.CreateUserDAL().LogIn(name, password);
        }
    }
}
