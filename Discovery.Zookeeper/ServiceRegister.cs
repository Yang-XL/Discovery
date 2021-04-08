using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using ZooProxy;

namespace Discovery.Zookeeper
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IServiceRegister
    {
        private readonly ZooPickerOptions _options;
        private readonly ILogger<ServiceRegister> _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zooPickerOptions"></param>
        /// <param name="logger"></param>
        public ServiceRegister(IOptionsMonitor<ZooPickerOptions> zooPickerOptions, ILogger<ServiceRegister> logger)
        {
            _options = zooPickerOptions.CurrentValue;
            zooPickerOptions.OnChange((opt) =>
            {
                
            });
            _logger = logger;
        }

        /// <summary>
        /// 服务组节点为 永久节点
        ///     服务节点为 临时节点
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task<bool> RegistAsync(Service service)
        {
            using (var zkClient = await CreateAndOpenZkClient())
            {
                var groupNode = await zkClient.ProxyNodeAsync(_options.Env);
                await groupNode.CreateAsync(Permission.All, Mode.Persistent, true);
                var serviceNode = await groupNode.ProxyNodeAsync(_options.ServiceName);
                await serviceNode.CreateAsync(Permission.All, Mode.Persistent, true);
                var instanceNode = await serviceNode.ProxyJsonNodeAsync<Service>(service.Id);
                await instanceNode.CreateAsync(service, Permission.All, Mode.Ephemeral);
            }
            return true;
        }
        /// <summary>
        /// 下线服务节点
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task UnRegistAsync(Service service)
        {
            using (var zkClient = await CreateAndOpenZkClient())
            {
                var groupNode = await zkClient.ProxyNodeAsync(_options.Env);
                var serviceNode = await groupNode.ProxyNodeAsync(_options.ServiceName);
                service.Status = 0;
                var instanceNode = await serviceNode.ProxyJsonNodeAsync<Service>(service.Id);
                await instanceNode.CreateAsync(service, Permission.All, Mode.Ephemeral);
            }
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        private async Task<ZooKeeperClient> CreateAndOpenZkClient()
        {
            var zkClient = new ZooKeeperClient(
                _options.ConnectionString,
                _options.SessionTimeout,
                _options.ConnectionTimeout);
            await zkClient.OpenAsync();
            zkClient.FirstConnected += (_, __) =>
            {
                _logger.LogInformation("Connect to zookeeper server successfully.");
            };
            zkClient.ReConnected += (_, __) =>
            {
                _logger.LogInformation("Reconnect to zookeeper server successfully.");
            };
            zkClient.Disconnected += (_, __) =>
            {
                _logger.LogWarning("Lost connection to zookeeper server.");
            };
            zkClient.SessionExpired += (_, __) =>
            {
                //TODO:SessionTimeOut
                _logger.LogWarning("Lost connection to zookeeper server.");
            };
            return zkClient;
        }


    }
}
