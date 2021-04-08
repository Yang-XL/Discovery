using Discovery.Enums;
using System;

namespace Discovery
{
    public class ServiceEvent :EventArgs
    {

        public ServiceEvent(ServiceStatus status, Service service)
        {
            Detial = service;
            Status = status;

        }
        /// <summary>
        /// 当前服务状态
        /// </summary>
        public ServiceStatus Status { get; set; }
        /// <summary>
        /// 服务详情
        /// </summary>
        public Service Detial { get; set; }        
                 
    }
}
