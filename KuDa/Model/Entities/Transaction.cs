using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Transaction
    {
        public Guid ID { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Guid CategoryID { get; set; }

        public Guid GroupID { get; set; }
        public Guid UserID { get; set; }
    }
}
