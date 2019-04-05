using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAppWithMongoDB.DbModels;
using Microsoft.Extensions.Options;
using FirstAppWithMongoDB.IRepository;
using FirstAppWithMongoDB.Model;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FirstAppWithMongoDB.Repository
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ObjectContext _context = null;

        public SubscriberRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(Subscriber subscriber)
        {
            await _context.Subscribers.InsertOneAsync(subscriber);
        }

        public async Task<IEnumerable<Subscriber>> GetAsync()
        {
            return await _context.Subscribers.Find(x => true).ToListAsync();
        }

        public async Task<Subscriber> Get(string id)
        {
          //  var subscriber = Builders<Subscriber>.Filter.Eq("_id", id);
            return await _context.Subscribers.Find(x=> x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
         // var subscriber = _context.Subscribers.Find(x => x.Id == id).FirstOrDefaultAsync();
            return await _context.Subscribers.DeleteOneAsync( x=> x.Id==id );
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Subscribers.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Subscriber subscriber)
        {
            await _context.Subscribers.ReplaceOneAsync(xx=> xx.Id==id, subscriber);
            return "";
        }
    }
}
