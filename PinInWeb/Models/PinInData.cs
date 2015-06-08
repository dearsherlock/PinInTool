using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinInWeb.Models
{
   public class PinInData
    {
        [BsonId]
        public string PinInKey { get; set; }
        public string PinInValue { get; set; }
    }
}
