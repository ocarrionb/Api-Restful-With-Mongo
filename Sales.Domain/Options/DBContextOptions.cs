using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Options
{
    public sealed class DBContextOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string DBContext { get; set; } = String.Empty;
    }
}
