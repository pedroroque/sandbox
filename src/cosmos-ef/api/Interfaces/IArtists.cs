namespace Api.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Data;
    using Api.Entities;

    public interface IArtists
    {
        Task<Artist> GetByIdAsync(string id);
        Task<Artist> AddAsync(Artist artist);
        Task<IEnumerable<Artist>> GetAllAsync();
    }
}