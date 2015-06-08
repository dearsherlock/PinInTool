using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinInWeb.Services
{
    public class MongoConfig
    {
        public IMongoDatabase Database;

        public MongoConfig()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            //var server = client.GetServer();
            Database = client.GetDatabase("pinindb");
        }
    }
}
