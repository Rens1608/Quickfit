using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IUserDAL
    {
        void UpdateUser(int id, string name, int age, int weight, int height, string gender);
        UserModel LogIn(string name, string password);
    }
}
