using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_redis_api.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace simple_redis_api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class TestController : BaseController
    {
        private readonly ICacheService _cacheService;
        public TestController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("Create/{count}")]
        public async Task<IActionResult> New(int count = 10000)
        {
            var models = new List<TestModel>();
            for (int i = 0; i < count; i++)
            {
                models.Add(new TestModel(Faker.Name.First(), Faker.Name.Last()));
            }

            await System.IO.File.WriteAllTextAsync("data.json", JsonConvert.SerializeObject(models));

            return ServiceResponse("Ok");
        }

        // [HttpGet("Create")]
        // public async Task<IActionResult> Create()
        // {
        //     var models = await _cacheService.GetAsync<List<TestModel>>("models") ?? new List<TestModel>();
        //     var model = new TestModel(Faker.Name.First(), Faker.Name.Last());
        //     models.Add(model);
        //     await _cacheService.SetAsync("models", models);
        //     return ServiceResponse(model);
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var models = await _cacheService.GetAsync<List<TestModel>>("models");
            if (models != null)
            {
                try
                {
                    var guidId = new Guid(id);
                    var model = models.FirstOrDefault(p => p.Id == guidId);
                    if (model != null)
                    {
                        return ServiceResponse(model);
                    }
                }
                catch (System.Exception)
                {
                }
            }
            return ServiceResponse("Üye bulunamadı");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Stopwatch watch = new Stopwatch();
            Console.WriteLine("başlanıyor...");
            var cache = await _cacheService.GetAsync<List<TestModel>>("models");
            Console.WriteLine("bitti...");

            watch.Start();
            if (cache == null)
            {
                Console.Write("cacheden gelmedi.");
                var json = System.IO.File.ReadAllText("data.json");
                var data = JsonConvert.DeserializeObject<List<TestModel>>(json);
                await _cacheService.SetAsync("models", data);
                watch.Stop();
                return ServiceResponse(new ResponseModel(watch.Elapsed.TotalMilliseconds, data));
            }
            watch.Stop();
            return ServiceResponse(new ResponseModel(watch.Elapsed.TotalMilliseconds, cache));
        }
    }
}