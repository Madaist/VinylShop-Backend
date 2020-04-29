using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.SongAlbumRepository;
namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongAlbumController : ControllerBase
    {
        public ISongAlbumRepository ISongAlbumRepository { get; set; }
        public SongAlbumController(ISongAlbumRepository repository)
        {
            ISongAlbumRepository = repository;
        }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<SongAlbum>> Get()
        {
            return ISongAlbumRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult<SongAlbum> Get(int id)
        {
            return ISongAlbumRepository.Get(id);
        }

        // POST: api/Provider
        [HttpPost]
        public SongAlbum Post(SongAlbumDTO value)
        {
            SongAlbum model = new SongAlbum()
            {
                SongId = value.SongId,
                AlbumId = value.AlbumId
            };
            return ISongAlbumRepository.Create(model);
        }

        // PUT: api/Provider/5
        [HttpPut("{id}")]
        public SongAlbum Put(int id, SongAlbumDTO value)
        {
            SongAlbum model = ISongAlbumRepository.Get(id);
            if (value.SongId != 0)
            {
                model.SongId = value.SongId;
            }
            if (value.AlbumId != 0)
            {
                model.AlbumId = value.AlbumId;
            }
            return ISongAlbumRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public SongAlbum Delete(int id)
        {
            SongAlbum songAlbum = ISongAlbumRepository.Get(id);
            return ISongAlbumRepository.Delete(songAlbum);
        }
    }
}
