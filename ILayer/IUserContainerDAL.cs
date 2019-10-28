using System;
using System.Collections.Generic;
using System.Text;

namespace ILayer
{
    public interface IUserContainerDAL
    {
        void Add(string userName);
        void Remove(string userName);
    }
}
