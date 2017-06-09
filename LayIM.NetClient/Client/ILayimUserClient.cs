using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Layim的业务逻辑接口
 */
namespace LayIM.NetClient
{
    internal interface ILayimUserClient
    {
        /// <summary>
        /// 获取layim初始化的数据信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        object GetInitInfo();

        /// <summary>
        /// 获取群员列表
        /// </summary>
        /// <returns></returns>
        object GetGroupMembers();

        /// <summary>
        /// 添加消息记录
        /// </summary>
        /// <returns></returns>
        Task<bool> AddMsg();
    }

}
