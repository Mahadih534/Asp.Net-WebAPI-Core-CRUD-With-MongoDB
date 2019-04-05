using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAppWithMongoDB.Model;
using MongoDB.Driver;

namespace FirstAppWithMongoDB.IRepository
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<Subscriber>> GetAsync();
        Task<Subscriber> Get(string id);
        Task Add(Subscriber subscriber);
        Task<string> Update(string id, Subscriber subscriber);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();

    }
}

