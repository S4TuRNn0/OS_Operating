using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;

namespace CRUDInventoryQuick.Repositorio
{
    public class RolRepository : IRepository<ASPNETROLES>
    {

        private readonly ApplicationDbContext _context;
        

        public RolRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ASPNETROLES>> GetAll()
        {
            return _context.ASPNETROLEs.ToList();
        }

        public async Task<ASPNETROLES> GetById(int id)
        {
            return _context.ASPNETROLEs.SingleOrDefault(c => c.Id.Equals(id));
        }

        public Task Add(ASPNETROLES aSPNETUSERROLE)
        {
            _context.AddAsync(aSPNETUSERROLE);
            _context.SaveChanges();
            return Task.CompletedTask;

        }

        public Task Delete(ASPNETROLES aSPNETUSERROLE)
        {
            _context.Remove(aSPNETUSERROLE);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<int> Update(ASPNETROLES aSPNETUSERROLE)
        {
            _context.Update(aSPNETUSERROLE);
            return await _context.SaveChangesAsync();

        }

        public Task Save()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

    }
}
