using SuperHeroAPI.Interfaces.Services;
using SuperHeroAPI.Models.SuperHeroModel;
using SuperHeroAPI.Repository;

namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly ISuperHeroRepository _repository;

        public SuperHeroService(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            await _repository.AddHero(hero);
            return await Get();
        }

        public Task<SuperHero> Delete(int id)
        {
            _repository.Delete(id);
            return GetById(id);
        }

        public async Task<List<SuperHero>> Get()
        {
            return await _repository.Get();
        }

        public async Task<SuperHero> GetById(int id)
        {
            var hero = await _repository.GetById(id);
            if (hero != null)
                return hero;
            else
                throw new BadHttpRequestException("Hero not found");
        }

        public async Task<List<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = await _repository.GetById(request.Id);
            if (hero != null)
            {
                hero.Name = request.Name;
                hero.FirstName = request.FirstName;
                hero.LastName = request.LastName;
                hero.Place = request.Place;

                await _repository.UpdateHero(request);
                await _repository.SaveChanges();
            }

            return await Get();
        }

        Task<List<SuperHero>> ISuperHeroService.UpdateHero(SuperHero request)
        {
            throw new NotImplementedException();
        }
    }
}
