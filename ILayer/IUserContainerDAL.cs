using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IUserContainerDAL
    {
        void Add(UserModel model, string connectionstring);
        void Delete(int id, string connectionstring);
        UserModel FindById(int id, string connectionstring);
        List<UserModel> GetAll(string connectionstring);
    }
}
