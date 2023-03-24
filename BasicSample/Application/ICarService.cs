using BasicSample.DbAccess.Models;

namespace BasicSample.Application
{
    public interface ICarService
    {
        /// <summary>
        /// 加油
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        string FillingUp(CancellationToken cancellationToken = default);

        IList<User> GetUserList();

        void CreateUser(string name);

        void UpdateUser(string from, string to);

        void DeleteUser(string name);
    }
}