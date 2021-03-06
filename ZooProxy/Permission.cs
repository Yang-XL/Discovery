using System;

namespace ZooProxy
{
    [Flags]
    public enum Permission
    {
        Read = 1,
        Write = 2,
        //ReadWrite = Read | Write,
        Create = 4,
        Delete = 8,
        Admin = 16,
        All = Read | Write | Create | Delete | Admin
    }
}
