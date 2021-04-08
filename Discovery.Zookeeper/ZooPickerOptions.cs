namespace Discovery.Zookeeper
{
    public class ZooPickerOptions
    {
        public const string CONFIG_PREFIX = "discovery:zoopicker";

        /// <summary>
        /// ZooKeeper服务连接字符串（ZooPicker服务发现的跟节点）
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// ZooKeeper会话超时时间，默认值为6,000ms
        /// </summary>
        public int SessionTimeout { get; set; } = 2000 * 3;

        /// <summary>
        /// ZooKeeper连接超时时间，默认值为20,000ms
        /// </summary>
        public int ConnectionTimeout { get; set; } = 1000 * 20;
        /// <summary>
        /// 环境变量
        /// </summary>
        public string Env { get; set; }
        /// <summary>
        /// 服务名
        /// </summary>
        public string ServiceName { get; set; }

    }
}
