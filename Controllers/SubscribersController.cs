using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAppWithMongoDB.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FirstAppWithMongoDB.Model;

namespace FirstAppWithMongoDB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscribersController(ISubscriberRepository subscriberRepository) {

            _subscriberRepository = subscriberRepository;

        }


        [HttpGet]
        public Task<string> GetAll()
        {
            return this.GetSubscribers();
        }


        private async Task<string> GetSubscribers()
        {

            var Subscriber = await _subscriberRepository.GetAsync();
            return JsonConvert.SerializeObject(Subscriber);
        }



        [HttpGet]
        public Task<string> Get(string id)
        {
            return this.GetSubscriber(id);
        }


        private async Task<string> GetSubscriber(string id)
        {

            var Subscriber = await _subscriberRepository.Get(id);
            return JsonConvert.SerializeObject(Subscriber);
        }





        [HttpPost]
        public async Task<string> AddUser([FromBody] Subscriber subscriber)
        {

            await _subscriberRepository.Add(subscriber);
            return "";
        }


        [HttpPut("{id}")]
       public async Task<string> UpdateSubscriber (string id, [FromBody] Subscriber subscriber)
        {
            
            if (string.IsNullOrEmpty(id))
            {
                return "Invalid id";
            }

          return  await _subscriberRepository.Update(id,subscriber);
            
        }


        [HttpDelete("{id}")]
        public async Task<string> DeleteSubscriber(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                return "Invalid id";
            }

            await _subscriberRepository.Remove(id);
            return "Successfully Deleted";
        }



        [HttpGet]
        public ActionResult<IEnumerable<string>> Test()
        {
            return new string[] { "value1", "value2" };
        }




    }
}