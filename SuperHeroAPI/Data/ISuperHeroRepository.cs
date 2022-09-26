using SuperHeroAPI.Models.SuperHeroModel;

namespace SuperHeroAPI.Data
{
    public interface ISuperHeroRepository
    {
        Task<List<SuperHero>> Get();
        Task<SuperHero> GetById(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>> UpdateHero(SuperHero request);
        Task<List<SuperHero>> Delete(int id);
        public Task SaveChanges();
    }
}
