namespace Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Api.Data;
    using Api.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;


    [ApiController]
    [Route("[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly MusicContext _dbContext;

        public ArtistsController(MusicContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var artists = await _dbContext.Set<Artist>().ToListAsync();
            return Ok(artists);
        }

        [HttpPost]
        public async Task<IActionResult> PostNewArtist(Artist artist)
        {
            var newArtist = await _dbContext.Set<Artist>().AddAsync(artist);
            await _dbContext.SaveChangesAsync();
            return Created("", newArtist.Entity);
        }
    }
}