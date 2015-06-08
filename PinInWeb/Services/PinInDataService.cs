using MongoDB.Driver;
using PinInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinInWeb.Services
{
    public class PinInDataService :MongoServiceBase
    {
        private PinInRepository _repo;
        public PinInDataService()
        {
            _repo = new PinInRepository(GetDB());
        }
        internal async Task<string> QueryByKey(string key) {
            return await _repo.QueryByKey(key);
        }
         
    }
}
