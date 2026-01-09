using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class GroupUser
    {
        public Guid ID { get; set; }

        public Guid UserID { get; set; }
        public Guid GroupID { get; set; }
    }
}
