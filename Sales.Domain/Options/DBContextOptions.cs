using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Options
{
    public sealed class DBContextOptions
    {
        public const string MongoConnection = "MongoConnection";
        public string ConnectionString { get; set; } = String.Empty;
        public string Database { get; set; } = String.Empty;
    }
}
