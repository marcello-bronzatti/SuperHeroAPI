using SuperHeroAPI.Models.SuperHeroModel;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Repository
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _context;

        public SuperHeroRepository(DataContext context)
        {
            _context = context;
        }

        public Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.Add(hero);
            return Get();
        }

        public Task<List<SuperHero>> Delete(int id)
        {
            _context.Remove(id);
            return Get();
        }

        public async Task<List<SuperHero>> Get()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero> GetById(int id)
        {
            return await _context.SuperHeroes.FirstOrDefaultAsync(h => h.Id == id);
        }

        public Task<List<SuperHero>> UpdateHero(SuperHero request)
        {
            _context.Update(request);
            return Get();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
