//using ECommerce.Application.Common.Interfaces;
//using ECommerce.Application.Common.Models;
//using Microsoft.Extensions.Options;
//using ServiceStack.Redis;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ECommerce.Application.Services
//{
//    internal class RedisCacheService : IRedisCacheService
//    {
//        public readonly IOptions<RedisConfiguration> _config;
//        private readonly RedisEndpoint conf = null;

//        public RedisCacheService(IOptions<RedisConfiguration> config)
//        {
//            _config = config;
//            conf = new RedisEndpoint { Host = _config.Value.Host, Port = _config.Value.Port, Db = _config.Value.DefaultDatabase, RetryTimeout = 1000 };
//        }
//        public T Get<T>(string key)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    return client.Get<T>(key);
//                }
//            }
//            catch
//            {
//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }
//        }

//        public IList<T> GetAll<T>(string key)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    var keys = client.SearchKeys(key);
//                    if (keys.Any())
//                    {
//                        IEnumerable<T> dataList = client.GetAll<T>(keys).Values;
//                        return dataList.ToList();
//                    }
//                    return new List<T>();
//                }
//            }
//            catch
//            {

//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }
//        }

//        public void Set(string key, object data)
//        {
//            Set(key, data, DateTime.Now.AddMinutes(_config.Value.Timeout));
//        }

//        public void Set(string key, object data, DateTime time)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    var dataSerialize = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
//                    {
//                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
//                    });
//                    client.Set(key, Encoding.UTF8.GetBytes(dataSerialize), time);
//                }
//            }
//            catch
//            {
//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }
//        }

//        public void SetAll<T>(IDictionary<string, T> values)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    client.SetAll(values);
//                }
//            }
//            catch
//            {
//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }

//        }

//        public int Count(string key)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    return client.SearchKeys(key).Where(s => s.Contains(":") && s.Contains("Mobile-RefreshToken")).ToList().Count;
//                }
//            }
//            catch
//            {
//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }
//        }

//        public bool IsSet(string key)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    return client.ContainsKey(key);
//                }
//            }
//            catch
//            {
//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }
//        }

//        public void Remove(string key)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    client.Remove(key);
//                }
//            }
//            catch
//            {
//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }
//        }

//        public void RemoveByPattern(string pattern)
//        {
//            try
//            {
//                using (IRedisClient client = new RedisClient(conf))
//                {
//                    var keys = client.SearchKeys(pattern);
//                    client.RemoveAll(keys);
//                }
//            }
//            catch
//            {
//                throw new StateException { StateCode = StateCode.UnexpectedError };
//            }
//        }
//    }
//}
