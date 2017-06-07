using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayIM.NetClient
{
    /// <summary>
    /// 不做实现
    /// </summary>
    public class LayimStorageConnection : IStorageConnection
    {
        public virtual void Dispose()
        {
        }

        public virtual object GetGroupMembers(long groupId)
        {
            throw new NotImplementedException();
        }

        public virtual string GetToken(long userId)
        {
            throw new NotImplementedException();
        }

        public virtual bool SaveToken(long userId, string token)
        {
            throw new NotImplementedException();
        }

        public virtual bool AddChatMsg(long fromUserId, long toUserId,string type, string msg, DateTime createAt)
        {
            throw new NotImplementedException();
        }

        public virtual object GetInitInfo(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
