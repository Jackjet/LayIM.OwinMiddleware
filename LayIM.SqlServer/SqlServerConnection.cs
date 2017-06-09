using Dapper;
using LayIM.NetClient;
using LayIM.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayIM.NetClient.Model;

namespace LayIM.SqlServer
{
    /// <summary>
    /// 此类为 LayIM  逻辑的真正实现。所有的上层调用都会调用到这里
    /// </summary>
    public class SqlServerConnection : LayimStorageConnection
    {
        private SqlServerStorage _storage;

        public SqlServerConnection(SqlServerStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// 获取用户基本信息 好友列表等
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public override object GetInitInfo(long userId)
        {
            return _storage.UseConnection<object>(connection =>
            {

                string sql = @"SELECT pk_id AS id,name AS username,[sign],avatar FROM dbo.[user] WHERE pk_id=@uid
SELECT pk_id AS id,name AS groupname FROM dbo.friend_group WHERE [user_id]=@uid
SELECT a.pk_id AS gid,c.pk_id AS id,c.name as username,c.[sign],c.avatar FROM dbo.friend_group A INNER JOIN dbo.friend_group_detail B ON a.pk_id=B.group_id LEFT JOIN dbo.[user] C ON B.[user_id]=c.pk_id WHERE a.[user_id]=@uid
  SELECT b.pk_id AS id,name AS groupname,avatar FROM dbo.big_group_detail A LEFT JOIN dbo.big_group B ON A.group_id=b.pk_id WHERE [user_id]=@uid";

                SqlMapper.GridReader reader = connection.QueryMultiple(sql, new { uid = userId });

                var result = new BaseListResult();
                result.mine = reader.ReadFirstOrDefault<UserModel>();
                //处理friend逻辑 start
                var friend = reader.Read<FriendGroupModel>();
                var groupUsers = reader.Read<GroupUserModel>();

                friend.ToList().ForEach(f =>
                {
                    //每一组的人分配给各个组
                    f.list = groupUsers?.Where(x => x.gid == f.id);
                });
                result.friend = friend;
                //处理friend逻辑 end
                //读取用户所在群
                result.group = reader.Read<BigGroupModel>();


                return new CommonResult { code = result.mine == null ? 1 : 0, msg = result.mine == null ? "用户不存在" : "", data = result };
            });
        }

        public override object GetGroupMembers(long groupId)
        {
            return _storage.UseConnection<object>(connection =>
            {
                GroupMemberResult result = new GroupMemberResult();
                string sql = $@"SELECT pk_id AS id,name AS username,[sign],avatar FROM dbo.[user] WHERE pk_id=(SELECT owner_id FROM dbo.big_group WHERE pk_id={groupId})
SELECT b.pk_id AS id,name AS username,B.[sign],B.avatar FROM dbo.big_group_detail A LEFT JOIN dbo.[user] B ON A.[user_id]=b.pk_id WHERE group_id={groupId}";
                SqlMapper.GridReader reader = connection.QueryMultiple(sql);

                result.owner = reader.Read<UserModel>().FirstOrDefault();
                result.list = reader.Read<UserModel>();

                return new CommonResult { code = 0, data = result, msg = "ok" };
            });
        }

        public override IEnumerable<LayimChatMessageViewModel> GetHistoryMessages(LayimHistoryParam param)
        {
            return _storage.UseConnection<IEnumerable<LayimChatMessageViewModel>>(connection =>
            {
                string timestampCondition = param.MsgTimestamp > 0 ? "AND A.[timestamp]<" + param.MsgTimestamp : "";

                var sql = $@"SELECT TOP {param.Page}  A.[user_id] AS [uid] ,
        A.msg AS content ,
        A.create_at AS addtime ,
        A.[timestamp] ,
        B.name ,
        B.avatar
FROM    dbo.chat_msg A
        LEFT JOIN dbo.[user] B ON A.[user_id] = B.pk_id WHERE A.room_id='{CreateRoom(param.UserId, param.ToId, param.Type)}' {timestampCondition} ORDER BY A.[timestamp] desc";

                var res = connection.Query<LayimChatMessageViewModel>(sql);
                return res.OrderBy(x => x.timestamp);
            });
        }

        /// <summary>
        /// 添加聊天消息记录
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override bool AddChatMsg(LayimChatMessageModel msg)
        {
            if (msg==null||msg.FromUserId == 0 || msg.ToUserId == 0) { return false; }

            return _storage.UseConnection<bool>(connection =>
            {
                string sql = @"INSERT INTO dbo.chat_msg( pk_id , user_id ,room_id ,msg ,create_at,timestamp ) VALUES  ( @msgid , @uid ,  @roomid ,@msg , @create,@timestamp)";

                var result = connection.Execute(sql,
                    new
                    {
                        msgid = Guid.NewGuid().ToString(),
                        uid = msg.FromUserId,
                        roomid = CreateRoom(msg.FromUserId, msg.ToUserId, msg.Type),
                        msg = msg.Message,
                        create = msg.CreateAt,
                        timestamp = msg.TimeStamp
                    });
                return result > 0;
            });
        }

        private string CreateRoom(long id1, long id2, string type)
        {
            if (type == Constants.ChatGroup)
            {
                return id2.ToString();
            }

            if (type == Constants.ChatFriend)
            {
                if (id1 > id2)
                {
                    return string.Format("{0}{1}", id2, id1);
                }
                return string.Format("{0}{1}", id1, id2);
            }

            return "";
        }
    }
}
