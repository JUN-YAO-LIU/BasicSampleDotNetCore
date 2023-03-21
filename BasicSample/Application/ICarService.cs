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

        /// <summary>
        /// 取得用戶列表
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///  用戶列表
        /// </returns>
        Task<IList<User>> GetUserListAsync(CancellationToken cancellationToken = default);

        IList<User> GetUserList();
    }
}