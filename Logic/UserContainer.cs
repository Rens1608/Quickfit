using System;
using System.Collections.Generic;
using System.Text;
using ILayer;
using Logic;

namespace LogicLayer
{
    class UserContainer : IUserContainerDAL
    {
        User user = new User();
        public void Add(string userName)
        {
            throw new NotImplementedException();
        }

        public void Remove(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
