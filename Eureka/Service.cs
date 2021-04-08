using Discovery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Discovery
{
    /// <summary>
    /// 服务
    /// </summary>
    public class Service
    {
        /// <summary>
        /// 主键ID 可以为 服务的IP 等唯一信息
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        public int Weigth { get; }
        /// <summary>
        /// 当前权重
        /// </summary>
        public int CurrentWeigth { get; set; }

        /// <summary>
        /// 有效权重
        /// </summary>
        public int EffectiveWeigth { get; set; }

        /// <summary>
        /// 服务地址
        /// </summary>
        public string Address { get; }
        /// <summary>
        /// 状态
        /// </summary>
        public ServiceStatus Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// 服务列表
    /// </summary>
    public class ServiceList
    {
        /// <summary>
        /// 服务列表
        /// </summary>
        List<Service> Services { get; }
        /// <summary>
        /// 服务组
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 下线一个服务
        /// </summary>
        /// <param name="id"></param>
        public void DownAsync(string id)
        {
            var item = Services.FirstOrDefault(a => a.Id == id);
            Services.Remove(item);
        }

        /// <summary>
        /// 降低权重
        ///     参考Nginx 平滑加权轮训
        /// </summary>
        /// <param name="id"></param>
        /// <param name="func">
        ///     In:  CurrentWeigth
        ///     Out: Result
        /// </param>
        public void EffectiveWeigthAsync(string id, Func<int, int> func)
        {
            var item = Services.FirstOrDefault(a => a.Id == id);
            item.CurrentWeigth = func(item.CurrentWeigth);
        }
        /// <summary>
        /// 上线服务
        /// </summary>
        /// <param name="service"></param>
        public void UpAsync(Service service)
        {
            Services.Add(service);
        }
    }
}
