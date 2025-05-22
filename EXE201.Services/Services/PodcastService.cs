// EXE201.Services/PodcastService.cs
using EXE201.Commons.Models;
using EXE201.Repository;

namespace EXE201.Services
{
    public interface IPodcastService
    {
        Task<List<Podcast>> GetAllAsync();
        Task<Podcast> GetByIdAsync(int id);
        Task AddAsync(Podcast podcast);
        Task UpdateAsync(Podcast podcast);
        Task DeleteAsync(int id);
    }

    public class PodcastService : IPodcastService
    {
        private readonly IPodcastRepository _repository;

        public PodcastService(IPodcastRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Podcast>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Podcast> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Podcast podcast)
        {
            podcast.CreateBy = DateTime.UtcNow.ToString("yyyy-MM-dd"); // Tự động gán ngày xuất bản
            await _repository.AddAsync(podcast);
        }

        public async Task UpdateAsync(Podcast podcast)
        {
            await _repository.UpdateAsync(podcast);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}