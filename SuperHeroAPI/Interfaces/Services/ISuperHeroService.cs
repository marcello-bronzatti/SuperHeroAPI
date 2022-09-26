using SuperHeroAPI.Models.SuperHeroModel;

namespace SuperHeroAPI.Interfaces.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> Get();
        Task<SuperHero> GetById(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>> UpdateHero(SuperHero request);
        Task<SuperHero> Delete(int id);
    }
}
