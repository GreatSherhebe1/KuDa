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
        public int ID { get; set; }

        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }

        public int GroupID { get; set; }
        public int ParentID { get; set; }
    }
}
