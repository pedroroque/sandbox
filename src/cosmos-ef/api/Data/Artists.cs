using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.Cosmos;

namespace Api.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Entities;
    using Api.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class Artists : IArtists
    {
        private readonly MusicContext _context;
        private readonly DbSet<Artist> _artists;

        public Artists(MusicContext context)
        {
            _context = context;
            _artists = _context.Set<Artist>();
        }

        public async Task<Artist> AddAsync(Artist artist)
        {
            var operationResult = await _artists.AddAsync(artist);
            await _context.SaveChangesAsync();
            return operationResult.Entity;
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _artists.ToListAsync();
        }

        public async Task<Artist> GetByIdAsync(string id)
        {
            try
            {
                return await _artists.FindAsync(id);
            }
            catch (CosmosException e)
            {
                if(e.StatusCode==HttpStatusCode.NotFound)
                    return null;
                throw;
            }
        }
    }
}