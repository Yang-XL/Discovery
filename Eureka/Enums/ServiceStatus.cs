namespace Discovery.Enums
{
    /// <summary>
    /// 服务状态
    /// </summary>
    public enum ServiceStatus
    {
        /// <summary>
        /// 上线
        /// </summary>
        Up,
        /// <summary>
        /// 下线
        /// </summary>
        Down,
        /// <summary>
        /// 健康的服务
        /// 上线后默认就是这个服务
        /// </summary>
        Health,
        /// <summary>
        /// 坏掉的服务
        /// 一般由客户端请求大量出错后自动改为UnHealth
        /// </summary>
        UnHealth
    }
}
