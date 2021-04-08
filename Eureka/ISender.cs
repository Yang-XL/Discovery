using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discovery
{
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISender 
    {
        Task<T> SendAsync<T>(Service service) where T : class;
    }
}
