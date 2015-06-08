using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinInWeb.Models
{
    public class PinInRepository : IPinInRepository
    {
        IMongoCollection<PinInData> mongoCollection;
        public async Task<string> QueryByKey(string key)
        {
            
            var list =await mongoCollection.Find<PinInData>(x => x.PinInKey == key).ToListAsync();
            
            foreach (var data in list)
            {
                return data.PinInValue;
                //     Console.WriteLine(data.PinInValue);
            }
            return "";
            
        }

       

        public PinInRepository(IMongoDatabase database)
        {
            if (database == null) throw new NullReferenceException("Mongodatabase cannot be null. Please check your settings!");
            mongoCollection=database.GetCollection<PinInData>("mydata");
            
        }

    }
}
