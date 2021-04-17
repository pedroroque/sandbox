using Microsoft.Azure.Cosmos.Linq;

namespace Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Api.Dto.Request;
    using Api.Entities;
    using Api.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtists _artists;

        public ArtistsController(IArtists artists)
        {
            _artists = artists;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var artists = await _artists.GetAllAsync();
            return Ok(artists.Select(x => new Dto.Response.Artist(x.Id, x.Name)));
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var artist = await _artists.GetByIdAsync(id);

            return artist == null ? NotFound() : Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> PostNewArtist(NewArtist artist)
        {
            var newArtist = new Artist(artist.Name);
            var existing = await _artists.GetByIdAsync(newArtist.Id);
            if (existing != null) return Conflict();

            await _artists.AddAsync(new Artist(artist.Name));
            return Created(
                Url.Link(nameof(GetById), new { id = newArtist.Id }),
                new Dto.Response.Artist(newArtist.Id, newArtist.Name)
            );
        }
    }
}