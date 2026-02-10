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
        public int ID { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CategoryID { get; set; }

        public int GroupID { get; set; }
        public int UserID { get; set; }
    }
}
