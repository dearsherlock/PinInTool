using PinInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinInWeb.Models
{
    public interface IPinInRepository : IRepository<Task<string>>
    {

    }
}
