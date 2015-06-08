using MongoDB.Driver;
using PinInPCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace BatchConvertFile
{
    public class PinInDao
    {
        private MongoClient _mongoClient;

        IMongoDatabase db;
        public PinInDao()
        {
            // MongoDB 連線字串
            
            string connectionString = "mongodb://127.0.0.1:27017";
            // 產生 MongoClient 物件

            var client = new MongoClient(connectionString);
            // 取得 MongoDatabase 物件

            db = client.GetDatabase("pinindb");
        }

        public async void InvertData(string key,string value) {

            var collection = db.GetCollection<PinInData>("mydata");
            await collection.InsertOneAsync(new PinInData { PinInKey =key, PinInValue=value });
        }

        public async Task<string> QueryByKey(string key) {
            using (Benchmark.Start("QueryByKey = " +key))
            {
                var collection = db.GetCollection<PinInData>("mydata");

                var list = await collection.Find(x => x.PinInKey == key).ToListAsync();
                
                foreach (var data in list)
                {
                    return data.PinInValue;
               //     Console.WriteLine(data.PinInValue);
                }
                return "";

            }
        }
        public async Task QueryByValue(string value)
        {
            using (Benchmark.Start("QueryByValue=" + value))
            {
                var collection = db.GetCollection<PinInData>("mydata");

                var list = await collection.Find(x => x.PinInValue == value).ToListAsync();
                foreach (var data in list)
                {
                //    Console.WriteLine(data.PinInValue);
                }
            }
        }

        public async void InsertManyData(List<PinInData> pinDatas)
        {

            //  var database = client.GetDatabase("foo");
            var collection = db.GetCollection<PinInData>("mydata");
            try
            {
                //  var query = Query<product>.EQ(p => p.ID, id);

                var collection2 = db.GetCollection<BsonDocument>("mydata");
                var filter = new BsonDocument();


                //              long many=await  collection.CountAsync(filter);
                using (Benchmark.Start("Insert and query"))
                {
                    using (Benchmark.Start("InsertManyAsync"))
                    {
                        await collection.InsertManyAsync(pinDatas);
                        Console.WriteLine("Datas:"+pinDatas.Count);
                    }

                    long many = await collection.CountAsync(filter);


                }

                //await collection.InsertManyAsync(pinDatas);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // throw ex;
                return;
            }
            
          


            //Console.WriteLine(list.Count());
           
        }


        private void test_Count()
        {
            //var collection = db.GetCollection<BsonDocument>("PinInDatas");
            //long count =await collection.CountAsync();
            //Console.WriteLine(count);


        }

    }
}
