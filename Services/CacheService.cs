﻿using Newtonsoft.Json;
using StackExchange.Redis;

namespace JWT_Automapper_Project.Services
{
    public class CacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redisCon;
        private IDatabase _db;
        public CacheService(IConnectionMultiplexer redisCon)
        {
            _redisCon = redisCon;
            _db = redisCon.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public object RemoveData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
            }
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
    }
}

