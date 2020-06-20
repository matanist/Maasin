using System;
using System.Collections.Generic;

namespace Maasin.Datas.Models
{
    public partial class Branch
    {
        public Branch()
        {
            UserBranchMapping = new HashSet<UserBranchMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserBranchMapping> UserBranchMapping { get; set; }
    }
}
