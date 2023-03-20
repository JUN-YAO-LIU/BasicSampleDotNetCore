using BasicSample.DbAccess;
using BasicSample.DbAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicSample.Application
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _db;

        public CarService(ApplicationDbContext db)
        {
            _db = db;
        }

        public string FillingUp(CancellationToken cancellationToken = default)
        {
            return "需要加油";
        }

        public async Task<IList<User>> GetUserList(CancellationToken cancellationToken = default)
        {
            var result = await _db.Users.ToListAsync(cancellationToken);
            return result;
        }
    }
}