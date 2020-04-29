using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.ArtistRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        public IArtistRepository IArtistRepository { get; set; }
        public ArtistController(IArtistRepository repository)
        {
            IArtistRepository = repository;
        }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
        {
            return IArtistRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            return IArtistRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public Artist Post(ArtistDTO value)
        {
            Artist model = new Artist()
            {
                Name = value.Name,
                Nationality=value.Nationality
            };
            return IArtistRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public Artist Put(int id, ArtistDTO value)
        {
            Artist model = IArtistRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Nationality != null)
            {
                model.Nationality = value.Nationality;
            }
            return IArtistRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Artist Delete(int id)
        {
            Artist artist = IArtistRepository.Get(id);
            return IArtistRepository.Delete(artist);
        }
    }
}
