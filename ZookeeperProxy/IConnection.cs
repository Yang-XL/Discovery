using org.apache.zookeeper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZookeeperProxy
{
    public interface IConnection
    {
        /// <summary>
        /// 第一次成功连接到服务器事件
        /// </summary>
        public Action<Watcher> FirstConnected { get; }

        /// <summary>
        /// 丢失连接后，重新连接到服务器事件
        /// </summary>
        public Action<Watcher> ReConnected { get; }

        /// <summary>
        /// 连接中断事件
        /// </summary>
        public Action<Watcher> Disconnected { get; }

        /// <summary>
        /// Session过期事件（此时临时节点已经删除）
        /// </summary>
        public Action<Watcher> SessionExpired { get; }

    }
}
