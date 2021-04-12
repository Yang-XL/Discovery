using org.apache.zookeeper;
using System;
using System.Threading.Tasks;

namespace ZookeeperProxy.Imp
{
    public class ConnectionWatcher : Watcher, IConnection
    {
        public TaskCompletionSource<Event.KeeperState> Tcs { get; }
        private bool _firstConnected = true;

        /// <summary>
        /// 第一次成功连接到服务器事件
        /// </summary>
        public Action<Watcher> FirstConnected { get; set; }

        /// <summary>
        /// 丢失连接后，重新连接到服务器事件
        /// </summary>
        public Action<Watcher> ReConnected { get; set; }

        /// <summary>
        /// 连接中断事件
        /// </summary>
        public Action<Watcher> Disconnected { get; set; }

        /// <summary>
        /// Session过期事件（此时临时节点已经删除）
        /// </summary>
        public Action<Watcher> SessionExpired { get; set; }

        public ConnectionWatcher(TaskCompletionSource<Event.KeeperState> tcs = null)
        {
            Tcs = tcs ?? new TaskCompletionSource<Event.KeeperState>();
        }

        public override Task process(WatchedEvent @event)
        {
            var state = @event.getState();
            if (state == Event.KeeperState.SyncConnected)
            {
                if (Tcs.TrySetResult(state))
                {
                    _firstConnected = false;
                    FirstConnected(this);
                }
                else if (!_firstConnected)
                {
                    ReConnected(this);
                }
            }
            else if (state == Event.KeeperState.Disconnected)
            {
                Disconnected(this);
            }
            else if (state == Event.KeeperState.Expired)
            {
                SessionExpired(this);
            }
            return Task.CompletedTask;
        }

        public static ConnectionWatcher Default => new ConnectionWatcher();

    }
}
