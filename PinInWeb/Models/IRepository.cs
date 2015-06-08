using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PinInWeb.Models
{
    public interface IRepository<T>
    {
        T QueryByKey(string key);
    }
}