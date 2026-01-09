using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Group
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid MasterID { get; set; }
    }
}
