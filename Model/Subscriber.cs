using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAppWithMongoDB.Model
{
    public class Subscriber
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string Country { get; set; }

        public string  Address { get; set; }
    }
}
