using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinInWeb.Services
{
    public class MongoServiceBase
    {
        public IMongoDatabase GetDB()
        {
            var db = new MongoConfig();
            return db.Database;
        }
    }
}
