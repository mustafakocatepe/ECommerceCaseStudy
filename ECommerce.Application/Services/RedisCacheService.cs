using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    internal class RedisCacheService : IRedisCacheService
    {
        public readonly IOptions<RedisConfiguration> _config;
        private readonly RedisEndpoint conf = null;

        public RedisCacheService(IOptions<RedisConfiguration> config)
        {
            _config = config;
            //conf = new RedisEndpoint { Host = _config.Value.Host, Port = _config.Value.Port, Db = _config.Value.DefaultDatabase, RetryTimeout = 1000 }; // TO DO 
            conf = new RedisEndpoint { Host = "redis", Port = 6379, Db = 4, RetryTimeout = 1000 }; //Docker
            // conf = new RedisEndpoint { Host = "127.0.0.1", Port = 6379, Db = 4, RetryTimeout = 1000 }; // local
        }
        public T Get<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.Get<T>(key);
                }
            }
            catch
            {
                throw new Exception { };
            }
        }

        public IList<T> GetAll<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var keys = client.SearchKeys(key);
                    if (keys.Any())
                    {
                        IEnumerable<T> dataList = client.GetAll<T>(keys).Values;
                        return dataList.ToList();
                    }
                    return new List<T>();
                }
            }
            catch
            {

                throw new Exception { };

            }
        }

        public void Set(string key, object data)
        {
            Set(key, data, DateTime.Now.AddMinutes(_config.Value.Timeout));
        }

        public void Set(string key, object data, DateTime time)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var dataSerialize = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });
                    client.Set(key, Encoding.UTF8.GetBytes(dataSerialize), time);
                }
            }
            catch
            {
                throw new Exception { };

            }
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    client.SetAll(values);
                }
            }
            catch
            {
                throw new Exception { };
            }

        }

        public int Count(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.SearchKeys(key).Where(s => s.Contains(":") && s.Contains("Mobile-RefreshToken")).ToList().Count;
                }
            }
            catch
            {
                throw new Exception { };
            }
        }

        public bool IsSet(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    return client.ContainsKey(key);
                }
            }
            catch
            {
                throw new Exception { };
            }
        }

        public void Remove(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    client.Remove(key);
                }
            }
            catch
            {
                throw new Exception { };
            }
        }

        public void RemoveByPattern(string pattern)
        {
            try
            {
                using (IRedisClient client = new RedisClient(conf))
                {
                    var keys = client.SearchKeys(pattern);
                    client.RemoveAll(keys);
                }
            }
            catch
            {
                throw new Exception { };
            }
        }
    }
}
