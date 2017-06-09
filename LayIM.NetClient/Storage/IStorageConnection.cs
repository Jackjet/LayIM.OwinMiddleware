using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayIM.NetClient
{
    /// <summary>
    /// layim数据调用接口
    /// 目前在 Layim.SqlServer SqlServerConnection中实现具体方法
    /// </summary>

    public interface IStorageConnection : IDisposable
    {
        /// <summary>
        /// 读取历史记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="toId"></param>
        /// <param name="type"></param>
        /// <returns></returns>

        IEnumerable<Model.LayimChatMessageViewModel> GetHistoryMessages(Model.LayimHistoryParam param);
        /// <summary>
        /// 获取Layim初始化数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object GetInitInfo(long userId);

        /// <summary>
        /// 获取某个群组的用户列表
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        object GetGroupMembers(long groupId);

        /// <summary>
        /// 保存融云Token ，当融云设置token永久的时候可以永久保存数据库
        /// 也可用缓存方案替代
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        bool SaveToken(long userId, string token);

        /// <summary>
        /// 获取用户Token
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetToken(long userId);

        /// <summary>
        /// 添加历史记录信息
        /// </summary>
        /// <param name="fromUserId">发送消息人</param>
        /// <param name="toUserId">接收消息人或者群组ID</param>
        /// <param name="msg">消息内容</param>
        /// <param name="createAt">发送时间</param>
        /// <returns>返回结果</returns>
        bool AddChatMsg(Model.LayimChatMessageModel msg);

    }
}
