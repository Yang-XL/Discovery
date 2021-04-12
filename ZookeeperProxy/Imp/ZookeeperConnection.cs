using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using org.apache.zookeeper;
using System;
using System.Threading.Tasks;

namespace ZookeeperProxy.Imp
{
    public class ZookeeperConnection : ZooKeeper, IConnection,IDisposable
    {
        private readonly ILogger<ZookeeperConnection> _logger;

        private readonly static ConnectionWatcher defaultWatcher = new ConnectionWatcher();
        

        public ZookeeperConnection(IOptions<ZooOptions> options) 
            : base(options.Value.ConnectString, options.Value.SessionTimeout, defaultWatcher, false)
        {



        }             

        public Action<Watcher> FirstConnected => throw new NotImplementedException();

        public Action<Watcher> ReConnected => throw new NotImplementedException();

        public Action<Watcher> Disconnected => throw new NotImplementedException();

        public Action<Watcher> SessionExpired => throw new NotImplementedException();

        public Task CloseAsync()
        {
            return closeAsync();
        }

        public async void Dispose()
        {
            await CloseAsync();
        }       
    }
}
