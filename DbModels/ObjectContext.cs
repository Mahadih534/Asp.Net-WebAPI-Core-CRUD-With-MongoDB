using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FirstAppWithMongoDB.Model;

namespace FirstAppWithMongoDB.DbModels
{
    public class ObjectContext
    {

        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _database = null;


        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.IConfigurationRoot;
            settings.Value.ConnectionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoDB:Database").Value;

            var Client = new MongoClient(settings.Value.ConnectionString);

            if (Client != null)
            {
                _database = Client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Subscriber> Subscribers
        {
            get
            {
                return _database.GetCollection<Subscriber>("Subscriber");
            }
        }

    }
}
