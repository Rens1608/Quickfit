using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IUserContainerDAL
    {
        void Add(UserModel model);
        void Delete(int id);
        UserModel FindById(int id);
    }
}
