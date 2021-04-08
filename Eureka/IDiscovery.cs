using System.Threading.Tasks;

namespace Discovery
{
    /// <summary>
    /// 发现
    /// </summary>
    public interface IServiceDiscovery
    {
        /// <summary>
        /// 发现一个服务
        /// </summary>
        /// <param name="groupoName"></param>
        /// <returns></returns>
        Task<Service> DiscoveryAsync(string groupoName);
        /// <summary>
        /// 降低服务权重
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Task ReduceWgith(string serviceId);
        
    }
}
