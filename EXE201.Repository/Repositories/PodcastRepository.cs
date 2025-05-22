using EXE201.Commons.Models;
using Microsoft.EntityFrameworkCore;
using System;
using EXE201.Commons.Data;

namespace EXE201.Repository
{
    public interface IPodcastRepository
    {
        Task<List<Podcast>> GetAllAsync();
        Task<Podcast> GetByIdAsync(int id);
        Task AddAsync(Podcast podcast);
        Task UpdateAsync(Podcast podcast);
        Task DeleteAsync(int id);
    }

    public class PodcastRepository : IPodcastRepository
    {
        private readonly ApplicationDbContext _context;

        public PodcastRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Podcast>> GetAllAsync()
        {
            return await _context.Podcasts.ToListAsync();
        }

        public async Task<Podcast> GetByIdAsync(int id)
        {
            return await _context.Podcasts.FindAsync(id);
        }

        public async Task AddAsync(Podcast podcast)
        {
            await _context.Podcasts.AddAsync(podcast);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Podcast podcast)
        {
            _context.Podcasts.Update(podcast);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var podcast = await _context.Podcasts.FindAsync(id);
            if (podcast != null)
            {
                _context.Podcasts.Remove(podcast);
                await _context.SaveChangesAsync();
            }
        }
    }
}