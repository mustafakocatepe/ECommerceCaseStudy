using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Models
{
    public class RedisConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
        public int DefaultDatabase { get; set; }
        public int WebDatabase { get; set; }
    }
}
