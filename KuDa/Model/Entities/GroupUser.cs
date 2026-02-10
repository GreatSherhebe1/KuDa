using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class GroupUser
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public int GroupID { get; set; }
    }
}
