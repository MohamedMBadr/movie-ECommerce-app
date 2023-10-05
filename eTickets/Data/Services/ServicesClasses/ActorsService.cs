using eTickets.Data.Base.BaseClasses;
using eTickets.Data.Services.InterFaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services.ServicesClasses
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorService
    {

        public ActorsService(AppDbContext dbContext) : base(dbContext) { }

        //private readonly AppDbContext _context;
        //public ActorsService(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task AddAsync(Actor actor)
        //{
        //    await _context.Actors.AddAsync(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        //     _context.Actors.Remove(result);
        //    await _context.SaveChangesAsync();

        //}

        //public async Task<IEnumerable<Actor>> GetAllAsync()
        //{
        //    var result =await _context.Actors.ToListAsync();
        //    return result;
        //}

        //public async Task<Actor> GetByIdAsync(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        //    return result;
        //}

        //public async Task<Actor> UpdateAsync(int id, Actor newActor)
        //{
        //    _context.Update(newActor);
        //    await _context.SaveChangesAsync();
        //    return newActor;
        //}


    }
}
