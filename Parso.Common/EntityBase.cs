using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parso.Common
{
    public class EntityBase
    {
        public long Id { get; set; }
        public bool IsValid { get; set; }
        public bool HasChanged { get; set; }
    }
}
