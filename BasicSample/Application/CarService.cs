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

        public IList<User> GetUserList()
        {
            var result = _db.Users.ToList();
            return result;
        }

        public void CreateUser(string name)
        {
            _db.Users.Add(
                new User
                {
                    Name = name
                });
            _db.SaveChanges();
        }

        public void UpdateUser(string from, string to)
        {
            var user = _db.Users.Where(x => x.Name == from).First();
            user.Name = to;

            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}