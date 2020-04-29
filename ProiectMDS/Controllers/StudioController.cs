using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.StudioRepository;
using ProiectMDS.Repositories.ProviderRepository;
namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        public IStudioRepository IStudioRepository { get; set; }
        public IProviderRepository IProviderRepository { get; set; }
        public StudioController(IStudioRepository repository)
        {
            IStudioRepository = repository;
        }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Studio>> Get()
        {
            return IStudioRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Studio> Get(int id)
        {
            return IStudioRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public Studio Post(StudioDTO value)
        {
            Studio model = new Studio()
            {
                Name = value.Name,
                ProviderId = value.ProviderId
            };
            return IStudioRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Studio Put(int id, StudioDTO value)
        {
            Studio model = IStudioRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.ProviderId != 0)
            {
                model.ProviderId = value.ProviderId;
            }
            return IStudioRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Studio Delete(int id)
        {
            Studio studio = IStudioRepository.Get(id);
            return IStudioRepository.Delete(studio);
        }
    }
}
