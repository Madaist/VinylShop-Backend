using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.ArtistAlbumRepository;
namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistAlbumController : ControllerBase
    {
        public IArtistAlbumRepository IArtistAlbumRepository { get; set; }
        public ArtistAlbumController(IArtistAlbumRepository repository)
        {
            IArtistAlbumRepository = repository;
        }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<ArtistAlbum>> Get()
        {
            return IArtistAlbumRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<ArtistAlbum> Get(int id)
        {
            return IArtistAlbumRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public ArtistAlbum Post(ArtistAlbumDTO value)
        {
            ArtistAlbum model = new ArtistAlbum()
            {
                ArtistId= value.ArtistId,
                AlbumId=value.AlbumId
            };
            return IArtistAlbumRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public ArtistAlbum Put(int id, ArtistAlbumDTO value)
        {
            ArtistAlbum model = IArtistAlbumRepository.Get(id);
            if (value.ArtistId!= 0)
            {
                model.ArtistId = value.ArtistId;
            }
            if (value.AlbumId != 0)
            {
                model.AlbumId = value.AlbumId;
            }
            return IArtistAlbumRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ArtistAlbum Delete(int id)
        {
            ArtistAlbum artistAlbum = IArtistAlbumRepository.Get(id);
            return IArtistAlbumRepository.Delete(artistAlbum);
        }
    }
}
