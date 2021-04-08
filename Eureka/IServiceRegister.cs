using System.Threading.Tasks;

namespace Discovery
{
    /// <summary>
    /// 注册
    /// </summary>
    public interface IServiceRegister
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        Task<bool> RegistAsync(Service servuce);
        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        Task UnRegistAsync(Service service);


    }
}
