using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public Guid GroupID { get; set; }
        public Guid ParentID { get; set; }
    }
}
