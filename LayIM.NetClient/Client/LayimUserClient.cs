﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Layim业务逻辑基于LayimStorage的实现
 */
namespace LayIM.NetClient
{
    internal class LayimUserClient : ILayimUserClient
    {

        private LayimStorage _storage;
        private LayimRequest _request;
        private long _id;

        public LayimUserClient(LayimStorage storage, LayimRequest request) : this(storage, 0)
        {
            _request = request;
        }
        public LayimUserClient(LayimStorage storage,long id)
        {
            _storage = storage;
            _id = id;
        }
        /// <summary>
        /// 获取初始化信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public object GetInitInfo()
        {
            using (var connection = _storage.GetConnection())
            {
                return connection.GetInitInfo(_id);
            }
        }

        public object GetGroupMembers()
        {
            using (var connection = _storage.GetConnection())
            {
                return connection.GetGroupMembers(_id);
            }
        }

        public async Task<bool> AddMsg()
        {
            var dictParameters = await _request.GetFormKeyValuesAsync("uid", "toid", "type", "msg");

            long fUid = dictParameters["uid"].ToInt64();
            long tUid = dictParameters["toid"].ToInt64();

            string type = dictParameters["type"];
            string msg = dictParameters["msg"];

            using (var connection = _storage.GetConnection())
            {

                return connection.AddChatMsg(new Model.LayimChatMessageModel
                {
                    CreateAt = DateTime.Now,
                    FromUserId = fUid,
                    Message = msg,
                    ToUserId = tUid,
                    Type = type
                });
            }
        }
    }
}
